import { User } from "./User";

export class Schedule {
  id : number;
  SenderId: number;
  invitedId: number;
  Description :string;
  IsApporoved : boolean;
  sender : User;
  invited : User;
}
