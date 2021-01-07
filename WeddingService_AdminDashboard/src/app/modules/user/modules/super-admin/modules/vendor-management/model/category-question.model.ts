export class CategoryQuestionModel {
    serviceAnswer: ServiceAnswer[];
    id: number;
    question: string;
    serviceType: number;
    vendorLeadId: number;
    isForVendor: number;
    active: number;
    createdBy: number;
    createdAt: string;
    updatedBy: number;
    updatedAt: string;
    result;
}
export class ServiceAnswer {
    id: number;
    questionId: number;
    controlType: number;
    answer: string;
    value;
    active: number;
    createdBy: number;
    createdAt: string;
    updatedBy: number;
    updatedAt: string;
    controlTypeNavigation: string;
    question: string;
    vendorquestionanswers: any[]
}