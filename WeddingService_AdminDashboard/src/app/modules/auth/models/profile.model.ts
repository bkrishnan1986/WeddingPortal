import { Gender } from 'src/app/shared/enums/gender.enum';
import { UserType } from 'src/app/shared/enums/user-type.enum';

export class ProfileModel {
    gender: Gender;
    active: number;
    userName: string;
    parentId: string;
    password: string;
    firstName: string;
    lastName: string;
    nickName: string;
    userType: UserType;
    age: number;
    email: string;
    about: string;
    phone: string;
    createdBy: string;
    createdAt: Date;
    updateAt: Date;
    UpdatedBy: string;
}
