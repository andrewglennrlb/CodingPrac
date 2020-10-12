using DAL.DataContracts;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public enum ProjectStates
    {
        Draft = 1,
        Active = 2,
        Archived = 3,
        Completed = 4
    }
    public class Project : IHistoricalEntity, 
                           IReportable,
                           IHasStatus<ProjectStates>,
                           IHasWorkflow<ProjectStates>,
                           IHasAddress,
                           IHasLocale
    {
        [Key]
        public int ProjectId { get; set; }

        public string ProjectTitle { get; set; }

        public decimal EstimatedAmount { get; set; }
        
        public decimal PaidAmount { get; set; }

        public int CurrentReportingPeriod { get; set; }

        public string Currency { get; set; }

        public ProjectStates CurrentStatus { get; set; }

        public string ProjectType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ProjectPrincipalCurrencyISO { get; set; }

        public int ProjectLocaleId { get; set; }

        public int FunderId { get; set; }

        public int OrgGroupId { get; set; }

        public int ReportingPeriodId { get; set; }

        public int HistoricalEntityId { get; set; }

        public int AddressId { get; set; }
        public int AuthorId { get; set; }

        public int? ProjectVersion { get; set; }

        public int? ParentId { get; set; }

        public int LocaleId { get; set; }

        public bool archived { get; set; }

        [Computed]
        public List<CostCategory> CostCategory { get; set; }

        [Computed]
        public List<CostCategory> Contracts { get; set; }

        [Computed]
        public Funder Funder { get; set; }

        [Computed]
        public Address Address { get; set; }

        [Computed]
        public Currency ProjectCurrency { get; set; }

        [Computed]
        public Locale ProjectLocale { get; set; }

        [Computed]
        public List<FunderContact> FunderContacts { get; set; }       

        [Computed]
        public decimal CalculationAmount { get; set; }

        [Computed]
        public decimal? PartialContribution { get; set; }
        
        [Computed]
        public List<ProjectStates> NextStateTransitions { get; set; }

        [Computed]
        public Locale locale { get; set; }
        
    }
}
