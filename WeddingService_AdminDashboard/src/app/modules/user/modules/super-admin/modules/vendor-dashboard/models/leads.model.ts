export class LeadDetails{
    leads: Leads;
    leadSentDate: Date;
}

export class Leads {
    id: number;
    dataCollectionId: number;
    eventDate: string;
    eventLocation: number;
    leadId: string;
    owner: number;
    description: string;
    leadType: number;
    subLeadType: number;
    leadMode: number;
    leadStatusId: number;
    leadQuality: number;
    budget: number;
    valueInPercentage: number;
    revenue: number;
    cplvalue: number;
    commisionValue: number;
    walletStatus: number;
    walletStatusName: string;
    customerName: string;
    active: number;
    createdBy: number;
    createdAt: string;
    updatedBy: null;
    leadstatus: Array<LeadStatus>;
    
}
export class LeadStatus {
    leadId: number;
    leadStatusId: number;
    date: string;
    createdBy: number;
}