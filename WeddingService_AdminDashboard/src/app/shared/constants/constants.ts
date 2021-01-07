export class Constants {
    public static readonly EmailPattern = /^[_A-Za-z0-9]+(.[_A-Za-z0-9]+)*@[A-Za-z0-9-]+(.[A-Za-z0-9-]+)*(.[A-Za-z]{2,4})$/;
    public static readonly ValidationPattern = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})|([0-9]{10})+$/;

    // Messages
    public static readonly ErrorMessage = 'Something Went Wrong';
    public static readonly ErrorTitle = 'Sorry';
    public static readonly CreatedSuccessMessage = 'Successfully Created';
    public static readonly DeletedSuccessMessage = 'Successfully Deleted';
    public static readonly UpdatedSuccessMessage = 'Successfully Updated';
    public static readonly SuccessTitle = 'Success';
    public static readonly WarningTitle = 'Warning';
    public static readonly PasswordChanged = 'Password Changed Successfully';
    public static readonly PasswordMisMatch = 'New Password and Confirm Password does not match';
    public static readonly IncorrectLogin = 'Username or password is incorrect';
    public static readonly FillRequiredFields = 'Please fill the required fields';
    public static readonly DateValidationMessage = 'End Date should not be less than Start Date';


    // Constant ActivityStatus DB values

    public static readonly Assigned = 12;
    public static readonly ApprovalPending = 13;
    public static readonly Approved = 14;
    public static readonly Completed = 15;
    public static readonly Rejected = 16;
    public static readonly Deleted = 21;
    public static readonly Verified = 22;
    public static readonly Denied = 23;
    public static readonly VerificationPending = 24;

    // Status
    public static readonly ActiveStatus = 1;

    // Others
    public static readonly ActivityTypeId = 17;
    public static readonly SubCategoryId = 18;
    public static readonly OccurrenceId = 19;
    public static readonly UnitId = 20;
    public static readonly DummyParentId = 0;
    public static readonly PaidTo = 25;

    // Constant Names
    public static readonly Admin = 'Admin';
    public static readonly Client = 'Client';
    public static readonly Delete = 'Deleted';
    public static readonly Reject = 'Rejected';
    public static readonly NullMessage = 'null';

    //  Multicode String
    public static readonly ServiceType = 'Service Type';
    public static readonly City = 'City';
    public static readonly UserRoll = 'UserRoll';
    public static readonly DocumentType = 'DocumentType';
    public static readonly State = 'State';
    public static readonly PaymentMode = 'Payment Mode';
    public static readonly Mode = 'Mode';
    public static readonly WalletCategory = 'Category'; // wallet
    public static readonly AdjustmentType = 'Adjustment Type';
    public static readonly UserStatus = 'User Status'; // lead

    // Lead Status
    public static readonly FollowUp = 7;
    public static readonly Paused = 8;
    public static readonly Approval= 15;
    public static readonly Pending= 16;

    // Lead Mode
    public static readonly CplValue = 13;
    public static readonly CommisionValue = 14;

}
