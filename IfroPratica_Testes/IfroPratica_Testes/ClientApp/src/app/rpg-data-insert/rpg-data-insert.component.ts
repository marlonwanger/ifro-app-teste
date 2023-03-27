import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'rpg-data-insert',
  templateUrl: './rpg-data-insert.component.html',
})
export class RpgDataInsertComponent {

  model = new RpgCharacter(0, '', '', 0);

  submitted = false;

  constructor(public htttp: HttpClient, @Inject('BASE_URL') public baseUrl: string, private router: Router) {

  }

  onSubmit(): void {
    this.submitted = true;
  }

  Submit(): void {

    var newHero = new RpgCharacter(0, this.model.name, this.model.rpgClass, this.model.hitPoints);
    console.log(newHero);

    const serviceInsert = this.htttp.post<RpgCharacter>(this.baseUrl + "rpgchar", newHero)
      .pipe(catchError(err => of('Error', err)));


    serviceInsert.subscribe(rpgChar => {
      this.router.navigate(['/rpg-list']);
    })
  }

  //public rpgChars: RpgCharacter[] = [];

    

}


export class RpgCharacter {

  constructor(
    public id: number,
    public name: string,
    public rpgClass: string,
    public hitPoints: number
  ) { }
}
