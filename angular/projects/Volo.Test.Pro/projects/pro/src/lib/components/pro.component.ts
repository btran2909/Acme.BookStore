import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { AuthorDto, GetAuthorsInput } from '../models';
import { ProService } from '../services/pro.service';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { FormBuilder, FormGroup } from '@angular/forms';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import { ConfigStateService } from '@abp/ng.core';
import { Router } from '@angular/router';

@Component({
  selector: 'lib-pro',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './pro.component.html',
  styles: [],
})
export class ProComponent implements OnInit {
  data: PagedResultDto<AuthorDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetAuthorsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: AuthorDto;

  // isFeature: boolean | string = false;

  constructor(
    private service: ProService,
    public readonly list: ListService,
    public readonly track: TrackByService,
    private confirmation: ConfirmationService,
    private fb: FormBuilder,
    private config: ConfigStateService,
    private router: Router
  ) {
    // this.isFeature = config.getFeature("Pro.EnableLdapPro").toLocaleLowerCase()
    // const abpSession = JSON.parse(localStorage.getItem('abpSession'))
    // if(abpSession && !abpSession.tenant.id) {
    //   this.isFeature = 'true'
    // } else {
    //   if(this.isFeature == 'false')
    //     this.router.navigate(['/'])
    // }
  }

  ngOnInit(): void {
    // this.service.sample().subscribe(console.log);
    const getData = (query: ABP.PageQueryParams) =>
      this.service.getList({
        ...query,
        ...this.filters,
        filterText: query.filter,
      });
    const setData = (list: PagedResultDto<AuthorDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetAuthorsInput;
  }

  buildForm() {
    const {
      nameSurname,
      age,
    } = this.selected || {};

    this.form = this.fb.group({
      nameSurname: [nameSurname ?? null, []],
      age: [age ?? null, []],
    });
  }

  hideForm() {
    this.isModalOpen = false;
    this.form.reset();
  }

  showForm() {
    this.buildForm();
    this.isModalOpen = true;
  }

  submitForm() {
    if (this.form.invalid) return;

    const request = this.selected
      ? this.service.update(this.selected.id, this.form.value)
      : this.service.create(this.form.value);

    this.isModalBusy = true;

    request
      .pipe(
        finalize(() => (this.isModalBusy = false)),
        tap(() => this.hideForm()),
      )
      .subscribe(this.list.get);
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: AuthorDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: AuthorDto) {
    this.confirmation.warn(
      '::DeleteConfirmationMessage',
      '::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.id)),
    ).subscribe(this.list.get);
  }
}
