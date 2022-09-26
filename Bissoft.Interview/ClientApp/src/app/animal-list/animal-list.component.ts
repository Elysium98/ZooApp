import { Component, Inject, OnInit, Optional } from "@angular/core";
import { MAT_DIALOG_DATA } from "@angular/material";
import { Atype, IAnimal } from "../models/animal.model";

@Component({
  selector: "app-animal-list",
  templateUrl: "./animal-list.component.html",
  styleUrls: ["./animal-list.component.scss"],
})
export class AnimalListComponent implements OnInit {
  animals: IAnimal[];
  errorMsg: string = "";

  constructor(@Optional() @Inject(MAT_DIALOG_DATA) private data: IAnimal[]) {
    if (this.data.length === 0) {
      this.errorMsg = "Ingrijitorul nu detine niciun animal !";
    } else {
      this.errorMsg = "";
      this.animals = data;
      this.animals.map((val) => (val.animalType = Atype[val.animalType]));
      //  (val.animalType = Atype[val.animalType])
    }
  }

  change(event) {
    if (event.isUserInput) {
    }
  }
  ngOnInit() {}
}
