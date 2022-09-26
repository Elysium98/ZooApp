import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AddAnimalComponent } from "./add-animal/add-animal.component";
import { AddZookeeperComponent } from "./add-zookeeper/add-zookeeper.component";
import { AnimalListComponent } from "./animal-list/animal-list.component";
import { HomeComponent } from "./home/home.component";
import { ZooComponent } from "./zoo/zoo.component";

const routes: Routes = [
  { path: "add-zookeeper", component: AddZookeeperComponent },
  { path: "add-animal", component: AddAnimalComponent },
  { path: "animals", component: AnimalListComponent },
  { path: "home", component: HomeComponent },
  { path: "", component: HomeComponent, pathMatch: "full" },
  { path: "zoo", component: ZooComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
