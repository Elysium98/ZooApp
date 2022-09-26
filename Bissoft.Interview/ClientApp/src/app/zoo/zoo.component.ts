import { Component } from "@angular/core";
import { MatDialog, MatTableDataSource } from "@angular/material";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { AddAnimalComponent } from "../add-animal/add-animal.component";
import { AddZookeeperComponent } from "../add-zookeeper/add-zookeeper.component";
import { AnimalListComponent } from "../animal-list/animal-list.component";
import { Animal, IAnimal } from "../models/animal.model";
import { IZooKeeper, ZooKeeper } from "../models/zooKeeper.model";
import { AnimalService } from "../services/animal.service";
import { ZooKeeperService } from "../services/zoo-keeper.service";

@Component({
  selector: "app-zoo",
  templateUrl: "./zoo.component.html",
  styleUrls: ["./zoo.component.scss"],
})
export class ZooComponent {
  zooKeepers_header: string[] = ["zooKeepers_header"];
  displayedColumns: string[] = ["id", "name", "action", "animal"];
  zooKeepers: IZooKeeper[];
  animals: Animal[];

  constructor(
    private zooService: ZooKeeperService,
    private router: Router,
    public dialog: MatDialog,
    private animalService: AnimalService
  ) {
    this.getZooKeepers();
  }

  goToAddZooKeeper() {
    this.dialog
      .open(AddZookeeperComponent, {
        width: "400px",
        height: "auto",
      })
      .afterClosed()
      .subscribe((val) => {
        if (val === "save") {
          this.getZooKeepers();
        }
      });
  }

  goToAnimalList(id: number) {
    this.animalService.getAllAnimalsByZooKeeper$(id).subscribe((val) => {
      this.animals = val;

      this.dialog.open(AnimalListComponent, {
        width: "400px",
        height: "auto",
        data: this.animals,
      });
    });
  }

  goToEditZooKeeper(zooKeeper: IZooKeeper) {
    this.dialog
      .open(AddZookeeperComponent, {
        width: "400px",
        height: "auto",
        data: zooKeeper,
      })
      .afterClosed()
      .subscribe((val) => {
        if (val === "save") {
          this.getZooKeepers();
        }
      });
  }

  goToAddAnimal(zooKeeperId: number) {
    this.dialog
      .open(AddAnimalComponent, {
        width: "400px",
        height: "auto",
        data: zooKeeperId,
      })
      .afterClosed()
      .subscribe((val) => {
        if (val === "save") {
          this.getZooKeepers();
        }
      });
  }

  getZooKeepers() {
    this.zooService.getAll$().subscribe(
      (result) => {
        this.zooKeepers = result;
      },
      (error) => console.error(error)
    );
  }

  deleteZooKeeper(id: number) {
    this.zooService.deleteZooKeeper(id).subscribe(
      () => {
        this.getZooKeepers();
      },
      (error) => console.error(error)
    );
  }
}
