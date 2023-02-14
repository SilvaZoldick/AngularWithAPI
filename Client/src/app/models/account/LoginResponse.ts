import User from "./User";

export default interface LoginResponse{
  User: User;
  token: string;
}
