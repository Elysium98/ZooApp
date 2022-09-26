import { Component, Inject, OnInit, Optional } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { IZooKeeper, ZooKeeper } from "../models/zooKeeper.model";
import { ZooKeeperService } from "../services/zoo-keeper.service";

@Component({
  selector: "app-add-zookeeper",
  templateUrl: "./add-zookeeper.component.html",
  styleUrls: ["./add-zookeeper.component.scss"],
})
export class AddZookeeperComponent implements OnInit {
  editMode: boolean;
  addZooKeeperFormGroup: FormGroup;
  currentZooKeeper: IZooKeeper;
  zooKeeper: ZooKeeper = new ZooKeeper();
  matTitle: string;

  constructor(
    private dialogRef: MatDialogRef<AddZookeeperComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private data: IZooKeeper,
    private fb: FormBuilder,
    private zooService: ZooKeeperService
  ) {
    this.editMode = this.data != null ? true : false;

    if (this.editMode === true) {
      this.addZooKeeperFormGroup = this.fb.group({
        name: [""],
      });
    }
  }

  ngOnInit() {
    if (this.editMode === false) {
      this.matTitle = "Adăugați un ingrjitor";
    } else {
      this.matTitle = "Editați un ingrijitor";
    }

    if (this.editMode === false) {
      this.addZooKeeperFormGroup = this.fb.group({
        name: ["", Validators.required],
      });
    } else {
      this.currentZooKeeper = this.data;
      this.addZooKeeperFormGroup = this.fb.group({
        name: this.currentZooKeeper.name,
      });
    }
  }

  hasAddError(controlName: string, errorName: string) {
    return this.addZooKeeperFormGroup.controls[controlName].hasError(errorName);
  }
  onSubmit() {
    this.zooKeeper.name = this.addZooKeeperFormGroup.value.name;

    if (this.editMode === false) {
      let model = {
        name: this.zooKeeper.name,
      };

      this.zooService
        .addZooKeeper$(model)
        .subscribe(() => this.dialogRef.close("save"));
    } else {
      let model = {
        name: this.zooKeeper.name,
      };

      this.zooService
        .updateZooKeeper$(this.currentZooKeeper.id, model)
        .subscribe((data) => {
          console.log(data), this.dialogRef.close("save");
        });
    }
  }
}
