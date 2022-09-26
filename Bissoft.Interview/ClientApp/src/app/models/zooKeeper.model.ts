export interface IZooKeeper {
  id: number;
  name: string;
}
export class ZooKeeper implements IZooKeeper {
  id: number = 0;
  name: string = "";

  constructor(init?: Partial<ZooKeeper>) {
    Object.assign(this, init);
  }
}
