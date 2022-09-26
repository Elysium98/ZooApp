import { Component, Inject, OnInit, Optional } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { Animal, Atype, IAnimal } from "../models/animal.model";
import { IZooKeeper } from "../models/zooKeeper.model";
import { AnimalService } from "../services/animal.service";

@Component({
  selector: "app-add-animal",
  templateUrl: "./add-animal.component.html",
  styleUrls: ["./add-animal.component.scss"],
})
export class AddAnimalComponent implements OnInit {
  addAnimalFormGroup: FormGroup;
  animal: Animal = new Animal();
  zooKeeperId: number;
  animalTypes: Array<string> = [Atype[0], Atype[1], Atype[2]];

  constructor(
    private dialogRef: MatDialogRef<AddAnimalComponent>,
    private fb: FormBuilder,
    @Optional() @Inject(MAT_DIALOG_DATA) private data,
    private animalService: AnimalService
  ) {}

  ngOnInit() {
    this.addAnimalFormGroup = this.fb.group({
      animalType: ["", Validators.required],
      dateOfBirth: ["", Validators.required],
    });
    this.zooKeeperId = this.data;
    console.log(this.zooKeeperId);
  }

  onSubmit() {
    this.animal.animalType = Atype[this.addAnimalFormGroup.value.animalType];
    this.animal.dateOfBirth = this.addAnimalFormGroup.value.dateOfBirth;
    this.animal.zooKeeperId = this.zooKeeperId;

    console.log(Atype[this.animal.animalType]);

    let model = {
      animalType: this.animal.animalType,
      dateOfBirth: this.animal.dateOfBirth,
      zooKeeperId: this.animal.zooKeeperId,
    };

    this.animalService
      .addAnimal$(model)
      .subscribe(() => this.dialogRef.close("save"));
  }

  hasAddError(controlName: string, errorName: string) {
    return this.addAnimalFormGroup.controls[controlName].hasError(errorName);
  }
}
