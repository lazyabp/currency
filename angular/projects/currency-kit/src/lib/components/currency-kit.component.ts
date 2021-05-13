import { Component, OnInit } from '@angular/core';
import { CurrencyKitService } from '../services/currency-kit.service';

@Component({
  selector: 'lib-currency-kit',
  template: ` <p>currency-kit works!</p> `,
  styles: [],
})
export class CurrencyKitComponent implements OnInit {
  constructor(private service: CurrencyKitService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
