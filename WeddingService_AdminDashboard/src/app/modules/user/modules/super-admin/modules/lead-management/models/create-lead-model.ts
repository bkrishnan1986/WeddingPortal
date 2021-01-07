export class CreateLeadModel {
    customerId: number;

    customerName: string;
    customerEmail: string;
    customerPhone1: string;
    customerPhone2: string;
    customerLocation: string;
    createdBy: string;
    createdAt: string;
    leads: LeadDataModel[] = [];
}

export class LeadDataModel {
    leadId: string;
    owner: string;
    ownerName: string;
    description: string;
    eventLocation: string;
    leadType: string;
    eventDate: string;
    eventType: string;
    category: number;
    leadMode: string;
    cplvalue: string;
    commisionValue: string;
    budget: number;
    revenue: number;
    walletStatus: string;
    leadQuality: string;
    createdBy: number;
    leadStatusId: string;
    leadStatus: LeadStatusModel[];
}

export class LeadStatusModel {
    leadId: number;
    leadStatusId: string;
    date: string;
    createdBy: number;
}
