using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDeskOutSourcing.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminTbl",
                columns: table => new
                {
                    AdminID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTbl", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "CompanyFAQTbl",
                columns: table => new
                {
                    CompanyFAQID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FAQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFAQTbl", x => x.CompanyFAQID);
                });

            migrationBuilder.CreateTable(
                name: "CountryTbl",
                columns: table => new
                {
                    CountryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTbl", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "EducationTbl",
                columns: table => new
                {
                    EducationID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationTbl", x => x.EducationID);
                });

            migrationBuilder.CreateTable(
                name: "FreelancerFAQTbl",
                columns: table => new
                {
                    FreelancerFAQID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FAQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerFAQTbl", x => x.FreelancerFAQID);
                });

            migrationBuilder.CreateTable(
                name: "FreelancerTbl",
                columns: table => new
                {
                    FreelancerID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerTbl", x => x.FreelancerID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentModeTbl",
                columns: table => new
                {
                    PaymentModeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentModeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModeTbl", x => x.PaymentModeID);
                });

            migrationBuilder.CreateTable(
                name: "SkillCategoryTbl",
                columns: table => new
                {
                    SkillCategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCategoryTbl", x => x.SkillCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "TechnologyTbl",
                columns: table => new
                {
                    TechnologyID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnologyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologyTbl", x => x.TechnologyID);
                });

            migrationBuilder.CreateTable(
                name: "TermsAndConditonForCompanyTbl",
                columns: table => new
                {
                    TermsAndConditionRuleID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyRule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermsAndConditonForCompanyTbl", x => x.TermsAndConditionRuleID);
                });

            migrationBuilder.CreateTable(
                name: "TermsAndConditonForFreelancerTbl",
                columns: table => new
                {
                    TermsAndConditionRuleID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerRule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermsAndConditonForFreelancerTbl", x => x.TermsAndConditionRuleID);
                });

            migrationBuilder.CreateTable(
                name: "StateTbl",
                columns: table => new
                {
                    StateID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateTbl", x => x.StateID);
                    table.ForeignKey(
                        name: "FK_StateTbl_CountryTbl_CountryID",
                        column: x => x.CountryID,
                        principalTable: "CountryTbl",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FreelancerCertificationsTbl",
                columns: table => new
                {
                    FreelancerCertificationsID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerID = table.Column<long>(type: "bigint", nullable: false),
                    CertificateTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassingYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityInstituteName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerCertificationsTbl", x => x.FreelancerCertificationsID);
                    table.ForeignKey(
                        name: "FK_FreelancerCertificationsTbl_FreelancerTbl_FreelancerID",
                        column: x => x.FreelancerID,
                        principalTable: "FreelancerTbl",
                        principalColumn: "FreelancerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FreelancerEducationTbl",
                columns: table => new
                {
                    FreelancerEducationID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerID = table.Column<long>(type: "bigint", nullable: false),
                    EducationID = table.Column<long>(type: "bigint", nullable: false),
                    PassingYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityInstituteName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerEducationTbl", x => x.FreelancerEducationID);
                    table.ForeignKey(
                        name: "FK_FreelancerEducationTbl_EducationTbl_EducationID",
                        column: x => x.EducationID,
                        principalTable: "EducationTbl",
                        principalColumn: "EducationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FreelancerEducationTbl_FreelancerTbl_FreelancerID",
                        column: x => x.FreelancerID,
                        principalTable: "FreelancerTbl",
                        principalColumn: "FreelancerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FreelancerExperienceTbl",
                columns: table => new
                {
                    FreelancerExperienceID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerID = table.Column<long>(type: "bigint", nullable: false),
                    ExperienceInMonths = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerExperienceTbl", x => x.FreelancerExperienceID);
                    table.ForeignKey(
                        name: "FK_FreelancerExperienceTbl_FreelancerTbl_FreelancerID",
                        column: x => x.FreelancerID,
                        principalTable: "FreelancerTbl",
                        principalColumn: "FreelancerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FreelancerPreviousProjectsTbl",
                columns: table => new
                {
                    FreelancerPreviousProjectsID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerID = table.Column<long>(type: "bigint", nullable: false),
                    ProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerPreviousProjectsTbl", x => x.FreelancerPreviousProjectsID);
                    table.ForeignKey(
                        name: "FK_FreelancerPreviousProjectsTbl_FreelancerTbl_FreelancerID",
                        column: x => x.FreelancerID,
                        principalTable: "FreelancerTbl",
                        principalColumn: "FreelancerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillTbl",
                columns: table => new
                {
                    SkillID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillCategoryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTbl", x => x.SkillID);
                    table.ForeignKey(
                        name: "FK_SkillTbl_SkillCategoryTbl_SkillCategoryID",
                        column: x => x.SkillCategoryID,
                        principalTable: "SkillCategoryTbl",
                        principalColumn: "SkillCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityTbl",
                columns: table => new
                {
                    CityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTbl", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_CityTbl_StateTbl_StateID",
                        column: x => x.StateID,
                        principalTable: "StateTbl",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTbl",
                columns: table => new
                {
                    CompanyID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<long>(type: "bigint", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTbl", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_CompanyTbl_CityTbl_CityID",
                        column: x => x.CityID,
                        principalTable: "CityTbl",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_Locations_CityTbl_CityID",
                        column: x => x.CityID,
                        principalTable: "CityTbl",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTbl",
                columns: table => new
                {
                    ProjectID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false),
                    ProjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectPaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTermsAndConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpectedCompletionDurationDays = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTbl", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_ProjectTbl_CompanyTbl_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "CompanyTbl",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinishedProjectTbl",
                columns: table => new
                {
                    FinishedProjectID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<long>(type: "bigint", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedRemark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinishedProjectTbl", x => x.FinishedProjectID);
                    table.ForeignKey(
                        name: "FK_FinishedProjectTbl_ProjectTbl_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "ProjectTbl",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectApplicationTbl",
                columns: table => new
                {
                    ProjectApplicationID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerID = table.Column<long>(type: "bigint", nullable: false),
                    ProjectID = table.Column<long>(type: "bigint", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectApplicationTbl", x => x.ProjectApplicationID);
                    table.ForeignKey(
                        name: "FK_ProjectApplicationTbl_FreelancerTbl_FreelancerID",
                        column: x => x.FreelancerID,
                        principalTable: "FreelancerTbl",
                        principalColumn: "FreelancerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectApplicationTbl_ProjectTbl_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "ProjectTbl",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDocumentTbl",
                columns: table => new
                {
                    ProjectDocumentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectID = table.Column<long>(type: "bigint", nullable: false),
                    DocumentFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDocumentTbl", x => x.ProjectDocumentID);
                    table.ForeignKey(
                        name: "FK_ProjectDocumentTbl_ProjectTbl_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "ProjectTbl",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStagesTbl",
                columns: table => new
                {
                    ProjectStagesID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectStagesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectID = table.Column<long>(type: "bigint", nullable: false),
                    DurationInHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StepsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStagesTbl", x => x.ProjectStagesID);
                    table.ForeignKey(
                        name: "FK_ProjectStagesTbl_ProjectTbl_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "ProjectTbl",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskTbl",
                columns: table => new
                {
                    ProjectTaskID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectID = table.Column<long>(type: "bigint", nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaskStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskTbl", x => x.ProjectTaskID);
                    table.ForeignKey(
                        name: "FK_ProjectTaskTbl_ProjectTbl_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "ProjectTbl",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TerminatedProjectTbl",
                columns: table => new
                {
                    TerminatedProjectID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<long>(type: "bigint", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminationRemark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminatedProjectTbl", x => x.TerminatedProjectID);
                    table.ForeignKey(
                        name: "FK_TerminatedProjectTbl_ProjectTbl_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "ProjectTbl",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SelectedApplicationTbl",
                columns: table => new
                {
                    SelectedApplicationID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectApplicationID = table.Column<long>(type: "bigint", nullable: false),
                    SelectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NeedStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnyRemark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedApplicationTbl", x => x.SelectedApplicationID);
                    table.ForeignKey(
                        name: "FK_SelectedApplicationTbl_ProjectApplicationTbl_ProjectApplicationID",
                        column: x => x.ProjectApplicationID,
                        principalTable: "ProjectApplicationTbl",
                        principalColumn: "ProjectApplicationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskAssignmentTbl",
                columns: table => new
                {
                    ProjectTaskAssignmentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTaskID = table.Column<long>(type: "bigint", nullable: false),
                    FreelancerID = table.Column<long>(type: "bigint", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskAssignmentTbl", x => x.ProjectTaskAssignmentID);
                    table.ForeignKey(
                        name: "FK_ProjectTaskAssignmentTbl_FreelancerTbl_FreelancerID",
                        column: x => x.FreelancerID,
                        principalTable: "FreelancerTbl",
                        principalColumn: "FreelancerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectTaskAssignmentTbl_ProjectTaskTbl_ProjectTaskID",
                        column: x => x.ProjectTaskID,
                        principalTable: "ProjectTaskTbl",
                        principalColumn: "ProjectTaskID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskDocumentTbl",
                columns: table => new
                {
                    ProjectTaskDocumentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTaskID = table.Column<long>(type: "bigint", nullable: false),
                    ProjectDocumentFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskDocumentTbl", x => x.ProjectTaskDocumentID);
                    table.ForeignKey(
                        name: "FK_ProjectTaskDocumentTbl_ProjectTaskTbl_ProjectTaskID",
                        column: x => x.ProjectTaskID,
                        principalTable: "ProjectTaskTbl",
                        principalColumn: "ProjectTaskID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskQueryTbl",
                columns: table => new
                {
                    ProjectTaskQueryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QueryTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTaskID = table.Column<long>(type: "bigint", nullable: false),
                    QueryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSolved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskQueryTbl", x => x.ProjectTaskQueryID);
                    table.ForeignKey(
                        name: "FK_ProjectTaskQueryTbl_ProjectTaskTbl_ProjectTaskID",
                        column: x => x.ProjectTaskID,
                        principalTable: "ProjectTaskTbl",
                        principalColumn: "ProjectTaskID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAssignedTbl",
                columns: table => new
                {
                    ProjectAssignedID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectedApplicationID = table.Column<long>(type: "bigint", nullable: false),
                    ProjectID = table.Column<long>(type: "bigint", nullable: false),
                    AssignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAssignedTbl", x => x.ProjectAssignedID);
                    table.ForeignKey(
                        name: "FK_ProjectAssignedTbl_ProjectTbl_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "ProjectTbl",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectAssignedTbl_SelectedApplicationTbl_SelectedApplicationID",
                        column: x => x.SelectedApplicationID,
                        principalTable: "SelectedApplicationTbl",
                        principalColumn: "SelectedApplicationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskReportTbl",
                columns: table => new
                {
                    ProjectTaskReportID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTaskAssignmentID = table.Column<long>(type: "bigint", nullable: false),
                    ProjectTaskID = table.Column<long>(type: "bigint", nullable: false),
                    IsReviewed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskReportTbl", x => x.ProjectTaskReportID);
                    table.ForeignKey(
                        name: "FK_ProjectTaskReportTbl_ProjectTaskAssignmentTbl_ProjectTaskAssignmentID",
                        column: x => x.ProjectTaskAssignmentID,
                        principalTable: "ProjectTaskAssignmentTbl",
                        principalColumn: "ProjectTaskAssignmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectTaskReportTbl_ProjectTaskTbl_ProjectTaskID",
                        column: x => x.ProjectTaskID,
                        principalTable: "ProjectTaskTbl",
                        principalColumn: "ProjectTaskID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskQuerySolutionTbl",
                columns: table => new
                {
                    ProjectTaskQuerySolutionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTaskQueryID = table.Column<long>(type: "bigint", nullable: false),
                    SolutionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskQuerySolutionTbl", x => x.ProjectTaskQuerySolutionID);
                    table.ForeignKey(
                        name: "FK_ProjectTaskQuerySolutionTbl_ProjectTaskQueryTbl_ProjectTaskQueryID",
                        column: x => x.ProjectTaskQueryID,
                        principalTable: "ProjectTaskQueryTbl",
                        principalColumn: "ProjectTaskQueryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskReportConflictTbl",
                columns: table => new
                {
                    ProjectTaskReportConflictID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTaskReportID = table.Column<long>(type: "bigint", nullable: false),
                    ConflictDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConflictRemark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskReportConflictTbl", x => x.ProjectTaskReportConflictID);
                    table.ForeignKey(
                        name: "FK_ProjectTaskReportConflictTbl_ProjectTaskReportTbl_ProjectTaskReportID",
                        column: x => x.ProjectTaskReportID,
                        principalTable: "ProjectTaskReportTbl",
                        principalColumn: "ProjectTaskReportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskReportReleasePaymentConflictTbl",
                columns: table => new
                {
                    ProjectTaskReportReleasePaymentConflictID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTaskReportID = table.Column<long>(type: "bigint", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskReportReleasePaymentConflictTbl", x => x.ProjectTaskReportReleasePaymentConflictID);
                    table.ForeignKey(
                        name: "FK_ProjectTaskReportReleasePaymentConflictTbl_ProjectTaskReportTbl_ProjectTaskReportID",
                        column: x => x.ProjectTaskReportID,
                        principalTable: "ProjectTaskReportTbl",
                        principalColumn: "ProjectTaskReportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskReportReleasePaymentTbl",
                columns: table => new
                {
                    ProjectTaskReportReleasePaymentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTaskReportID = table.Column<long>(type: "bigint", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskReportReleasePaymentTbl", x => x.ProjectTaskReportReleasePaymentID);
                    table.ForeignKey(
                        name: "FK_ProjectTaskReportReleasePaymentTbl_ProjectTaskReportTbl_ProjectTaskReportID",
                        column: x => x.ProjectTaskReportID,
                        principalTable: "ProjectTaskReportTbl",
                        principalColumn: "ProjectTaskReportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskReportConflictSolutionTbl",
                columns: table => new
                {
                    ProjectTaskReportConflictSolutionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTaskReportConflictID = table.Column<long>(type: "bigint", nullable: false),
                    SolutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolutionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskReportConflictSolutionTbl", x => x.ProjectTaskReportConflictSolutionID);
                    table.ForeignKey(
                        name: "FK_ProjectTaskReportConflictSolutionTbl_ProjectTaskReportConflictTbl_ProjectTaskReportConflictID",
                        column: x => x.ProjectTaskReportConflictID,
                        principalTable: "ProjectTaskReportConflictTbl",
                        principalColumn: "ProjectTaskReportConflictID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskReportPaymentConflictSolutionTbl",
                columns: table => new
                {
                    ProjectTaskReportPaymentConflictSolutionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTaskReportPaymentConflictID = table.Column<long>(type: "bigint", nullable: false),
                    SolutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolutionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTaskReportReleasePaymentConflictID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskReportPaymentConflictSolutionTbl", x => x.ProjectTaskReportPaymentConflictSolutionID);
                    table.ForeignKey(
                        name: "FK_ProjectTaskReportPaymentConflictSolutionTbl_ProjectTaskReportReleasePaymentConflictTbl_ProjectTaskReportReleasePaymentConfli~",
                        column: x => x.ProjectTaskReportReleasePaymentConflictID,
                        principalTable: "ProjectTaskReportReleasePaymentConflictTbl",
                        principalColumn: "ProjectTaskReportReleasePaymentConflictID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityTbl_StateID",
                table: "CityTbl",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTbl_CityID",
                table: "CompanyTbl",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_FinishedProjectTbl_ProjectID",
                table: "FinishedProjectTbl",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerCertificationsTbl_FreelancerID",
                table: "FreelancerCertificationsTbl",
                column: "FreelancerID");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerEducationTbl_EducationID",
                table: "FreelancerEducationTbl",
                column: "EducationID");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerEducationTbl_FreelancerID",
                table: "FreelancerEducationTbl",
                column: "FreelancerID");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerExperienceTbl_FreelancerID",
                table: "FreelancerExperienceTbl",
                column: "FreelancerID");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerPreviousProjectsTbl_FreelancerID",
                table: "FreelancerPreviousProjectsTbl",
                column: "FreelancerID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityID",
                table: "Locations",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectApplicationTbl_FreelancerID",
                table: "ProjectApplicationTbl",
                column: "FreelancerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectApplicationTbl_ProjectID",
                table: "ProjectApplicationTbl",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssignedTbl_ProjectID",
                table: "ProjectAssignedTbl",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssignedTbl_SelectedApplicationID",
                table: "ProjectAssignedTbl",
                column: "SelectedApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDocumentTbl_ProjectID",
                table: "ProjectDocumentTbl",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStagesTbl_ProjectID",
                table: "ProjectStagesTbl",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskAssignmentTbl_FreelancerID",
                table: "ProjectTaskAssignmentTbl",
                column: "FreelancerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskAssignmentTbl_ProjectTaskID",
                table: "ProjectTaskAssignmentTbl",
                column: "ProjectTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskDocumentTbl_ProjectTaskID",
                table: "ProjectTaskDocumentTbl",
                column: "ProjectTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskQuerySolutionTbl_ProjectTaskQueryID",
                table: "ProjectTaskQuerySolutionTbl",
                column: "ProjectTaskQueryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskQueryTbl_ProjectTaskID",
                table: "ProjectTaskQueryTbl",
                column: "ProjectTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskReportConflictSolutionTbl_ProjectTaskReportConflictID",
                table: "ProjectTaskReportConflictSolutionTbl",
                column: "ProjectTaskReportConflictID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskReportConflictTbl_ProjectTaskReportID",
                table: "ProjectTaskReportConflictTbl",
                column: "ProjectTaskReportID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskReportPaymentConflictSolutionTbl_ProjectTaskReportReleasePaymentConflictID",
                table: "ProjectTaskReportPaymentConflictSolutionTbl",
                column: "ProjectTaskReportReleasePaymentConflictID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskReportReleasePaymentConflictTbl_ProjectTaskReportID",
                table: "ProjectTaskReportReleasePaymentConflictTbl",
                column: "ProjectTaskReportID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskReportReleasePaymentTbl_ProjectTaskReportID",
                table: "ProjectTaskReportReleasePaymentTbl",
                column: "ProjectTaskReportID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskReportTbl_ProjectTaskAssignmentID",
                table: "ProjectTaskReportTbl",
                column: "ProjectTaskAssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskReportTbl_ProjectTaskID",
                table: "ProjectTaskReportTbl",
                column: "ProjectTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskTbl_ProjectID",
                table: "ProjectTaskTbl",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTbl_CompanyID",
                table: "ProjectTbl",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedApplicationTbl_ProjectApplicationID",
                table: "SelectedApplicationTbl",
                column: "ProjectApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTbl_SkillCategoryID",
                table: "SkillTbl",
                column: "SkillCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_StateTbl_CountryID",
                table: "StateTbl",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_TerminatedProjectTbl_ProjectID",
                table: "TerminatedProjectTbl",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminTbl");

            migrationBuilder.DropTable(
                name: "CompanyFAQTbl");

            migrationBuilder.DropTable(
                name: "FinishedProjectTbl");

            migrationBuilder.DropTable(
                name: "FreelancerCertificationsTbl");

            migrationBuilder.DropTable(
                name: "FreelancerEducationTbl");

            migrationBuilder.DropTable(
                name: "FreelancerExperienceTbl");

            migrationBuilder.DropTable(
                name: "FreelancerFAQTbl");

            migrationBuilder.DropTable(
                name: "FreelancerPreviousProjectsTbl");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "PaymentModeTbl");

            migrationBuilder.DropTable(
                name: "ProjectAssignedTbl");

            migrationBuilder.DropTable(
                name: "ProjectDocumentTbl");

            migrationBuilder.DropTable(
                name: "ProjectStagesTbl");

            migrationBuilder.DropTable(
                name: "ProjectTaskDocumentTbl");

            migrationBuilder.DropTable(
                name: "ProjectTaskQuerySolutionTbl");

            migrationBuilder.DropTable(
                name: "ProjectTaskReportConflictSolutionTbl");

            migrationBuilder.DropTable(
                name: "ProjectTaskReportPaymentConflictSolutionTbl");

            migrationBuilder.DropTable(
                name: "ProjectTaskReportReleasePaymentTbl");

            migrationBuilder.DropTable(
                name: "SkillTbl");

            migrationBuilder.DropTable(
                name: "TechnologyTbl");

            migrationBuilder.DropTable(
                name: "TerminatedProjectTbl");

            migrationBuilder.DropTable(
                name: "TermsAndConditonForCompanyTbl");

            migrationBuilder.DropTable(
                name: "TermsAndConditonForFreelancerTbl");

            migrationBuilder.DropTable(
                name: "EducationTbl");

            migrationBuilder.DropTable(
                name: "SelectedApplicationTbl");

            migrationBuilder.DropTable(
                name: "ProjectTaskQueryTbl");

            migrationBuilder.DropTable(
                name: "ProjectTaskReportConflictTbl");

            migrationBuilder.DropTable(
                name: "ProjectTaskReportReleasePaymentConflictTbl");

            migrationBuilder.DropTable(
                name: "SkillCategoryTbl");

            migrationBuilder.DropTable(
                name: "ProjectApplicationTbl");

            migrationBuilder.DropTable(
                name: "ProjectTaskReportTbl");

            migrationBuilder.DropTable(
                name: "ProjectTaskAssignmentTbl");

            migrationBuilder.DropTable(
                name: "FreelancerTbl");

            migrationBuilder.DropTable(
                name: "ProjectTaskTbl");

            migrationBuilder.DropTable(
                name: "ProjectTbl");

            migrationBuilder.DropTable(
                name: "CompanyTbl");

            migrationBuilder.DropTable(
                name: "CityTbl");

            migrationBuilder.DropTable(
                name: "StateTbl");

            migrationBuilder.DropTable(
                name: "CountryTbl");
        }
    }
}
