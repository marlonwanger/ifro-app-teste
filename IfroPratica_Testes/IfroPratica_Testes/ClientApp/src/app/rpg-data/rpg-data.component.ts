import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'rpg-data',
  templateUrl: './rpg-data.component.html',
})
export class RpgDataComponent {

  public rpgChars: RpgCharacter[] = [];

  constructor(private htttp: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.GetAll();
  }

  Delete(id: number): void {

    var result = confirm("Deseja excluir a ficha?");

    if (result) {
      this.htttp.delete(`${this.baseUrl}rpgchar/${id}`).subscribe(result => {
        console.log(result);
        this.GetAll();
      })
    }

    return;
  }

  GetAll(): void {
    this.htttp.get<RpgCharacter[]>(this.baseUrl + 'rpgchar').subscribe(result => {
      this.rpgChars = result;
      console.log(result);
    }, error => console.log(error));
  }
}


interface RpgCharacter {
  id: number;
  name: string;
  rpgClass: string;
  hitPoints: number;
}
