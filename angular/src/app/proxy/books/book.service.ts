import type { BookCreateDto, BookDto, BookUpdateDto, BookWithNavigationPropertiesDto, GetBooksInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  apiName = 'Default';

  create = (input: BookCreateDto) =>
    this.restService.request<any, BookDto>({
      method: 'POST',
      url: `/api/app/books`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/books/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, BookDto>({
      method: 'GET',
      url: `/api/app/books/${id}`,
    },
    { apiName: this.apiName });

  getAuthorLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: `/api/app/books/author-lookup`,
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getList = (input: GetBooksInput) =>
    this.restService.request<any, PagedResultDto<BookWithNavigationPropertiesDto>>({
      method: 'GET',
      url: `/api/app/books`,
      params: { filterText: input.filterText, title: input.title, yearMin: input.yearMin, yearMax: input.yearMax, authorId: input.authorId, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, BookWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/app/books/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: BookUpdateDto) =>
    this.restService.request<any, BookDto>({
      method: 'PUT',
      url: `/api/app/books/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
