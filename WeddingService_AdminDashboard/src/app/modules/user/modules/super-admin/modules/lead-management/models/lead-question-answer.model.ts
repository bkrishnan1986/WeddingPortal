import { ServiceAnswer } from './category-question-answer.model';

export class LeadQuestionAnswers {
    active: number;
    answer: Answer;
    answerId: number;
    createdAt: string;
    createdBy: number;
    id: number;
    isForVendor: number;
    question: Question;
    questionId: number;
    serviceAnswer: Array<ServiceAnswer>
    updatedAt: string;
    updatedBy: string;
    vendorLeadId: 1
    vendoranswervalue: string;
}
export class Answer {
    active: number;
    answer: string;
    controlType: number;
    createdAt: string;
    createdBy: number;
    id: number;
    questionId: number;
    updatedAt: string;
    updatedBy: number;
}
export class Question {
    active: number;
    createdAt: string;
    createdBy: number;
    id: number;
    isForVendor: number;
    question: string;
    serviceType: number;
    serviceName: string;
    updatedAt: null
    updatedBy: null
    vendorLeadId: number;
}