import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-employees',
  standalone: false,
  templateUrl: './employees.html',
  styleUrl: './employees.css',
})
export class Employees {

  employeeId = '';

  constructor(private route: ActivatedRoute) {

    this.employeeId =
      this.route.snapshot.paramMap.get('id') || '';

  }

}
