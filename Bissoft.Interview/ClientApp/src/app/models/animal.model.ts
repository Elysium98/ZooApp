import { ZooKeeper } from "./zooKeeper.model";

export enum Atype {
  Carnivorous,
  Omnivoruous,
  Herbivorous,
}

export interface IAnimal {
  id: number;
  animalType: string;
  zooKeeperId: number;
  zooKeeper: ZooKeeper;
  dateOfBirth: Date;
}
export class Animal implements IAnimal {
  id: number = 0;
  animalType: string = "";
  zooKeeperId: number = 0;
  zooKeeper: ZooKeeper = new ZooKeeper();
  dateOfBirth: Date = new Date();

  constructor(init?: Partial<Animal>) {
    Object.assign(this, init);
  }
}
