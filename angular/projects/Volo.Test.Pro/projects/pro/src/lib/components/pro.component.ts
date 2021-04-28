import { Component, OnInit } from '@angular/core';
import { ProService } from '../services/pro.service';

@Component({
  selector: 'lib-pro',
  template: ` <p>BaoTran pro works!</p> `,
  styles: [],
})
export class ProComponent implements OnInit {
  constructor(private service: ProService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
