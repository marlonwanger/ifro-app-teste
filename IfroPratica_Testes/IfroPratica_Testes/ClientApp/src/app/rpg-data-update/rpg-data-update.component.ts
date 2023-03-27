import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'rpg-data-update',
  templateUrl: './rpg-data-update.component.html',
})
export class RpgDataUpdateComponent {

  model = new RpgCharacter(0, '', '', 0);

  submitted = false;


  id;

  constructor(public htttp: HttpClient, @Inject('BASE_URL') public baseUrl: string, private router: Router, private route: ActivatedRoute) {
    this.id = this.route.snapshot.paramMap.get('id');
    this.GetById();
  }

  GetById(): void {
    this.htttp.get<RpgCharacter>(this.baseUrl + 'rpgchar/' + this.id).subscribe(result => {
      this.model = result;
      console.log(result);
    }, error => console.log(error));
  }

  onSubmit(): void {
    this.submitted = true;
  }

  Submit(): void {


    const serviceInsert = this.htttp.put<RpgCharacter>(this.baseUrl + "rpgchar/" + this.id, this.model)
      .pipe(catchError(err => of('Error', err)));


    serviceInsert.subscribe(rpgChar => {
      console.log(rpgChar);
      this.router.navigate(['/rpg-list']);
    })
  }
}


export class RpgCharacter {
  constructor(
    public id: number,
    public name: string,
    public rpgClass: string,
    public hitPoints: number
  ) { }
}
