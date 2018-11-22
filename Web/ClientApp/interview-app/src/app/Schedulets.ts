import { User } from "./User";

export class Schedule {
  id : number;
  SenderId: number;
  InvitedId: number;
  Description :string;
  IsApporoved : boolean;
  sender : User;
  invinted : User;
}
