export class WalletLeadDetails{
    id: number;
    dataCollectionId: number;
    eventDate: Date;
    eventLocation: number;
    eventLocationName: string;
    leadId: string;
    owner: string;
    description: string;
    leadType: number;
    leadTypeName: string;
    eventType: number;
    eventTypeName: string;
    leadMode: number;
    leadModeName: string;
    category: number;
    categoryName: string;
    leadStatusId: number;
    leadStatusName: string;
    leadQuality: number;
    budget: number;
    revenue: number;
    cplvalue: number;
    commisionValue: string;
    walletStatus: number;
    walletStatusName: string;
    customerName: string;
    customerPhone: string;
    customerEmail: string;
    active: number;
    createdBy: number;
    createdAt: Date;
    leadstatus: Array<LeadStatus>;
    leadvalidation: [];
    leadassign: Array<LeadAssign>;
    leadquote: []
    }

    export class LeadStatus    {
        id: number;
        leadId: number;
        leadName: string;
        leadStatusId: number;
        statusName: string;
        date: Date;
        active: number;
        createdBy: number;
        createdAt: Date
        }

    export class LeadAssign    {
        id: number;
        leadId: number;
        leadSentDate: Date;
        vendorId: number;
        vendorName: string;
        category: number;
        categoryName: string;
        proposedBudget: number;
        packs: number;
        remarks: string;
        active: number;
        createdBy: number;
        createdAt: Date;
        updatedBy: number;
        updatedAt: Date
        }   