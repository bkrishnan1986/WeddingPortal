import { Gender } from 'src/app/shared/enums/gender.enum';
import { UserType } from '../enums/user-type.enum';

export class ProfileModel {
    gender: Gender;
    userType: UserType;
    userName: string;
    parentId: string;
    password: string;
    firstName: string;
    lastName: string;
    nickName: string;
    age: number;
    email: string;
    about: string;
    phone: string;
    active: number;
    createdBy: string;
    createdAt: Date;
    updatedBy: string;
    updatedAt: Date;
}
