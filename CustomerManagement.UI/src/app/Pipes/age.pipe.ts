import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'age',
  standalone: true
})
export class AgePipe implements PipeTransform {

  transform(value: Date): number {
    const currentYear = new Date().getFullYear();
    const dob = new Date(value);
    const dobYear = dob.getFullYear();
    return currentYear - dobYear;
  }

}
