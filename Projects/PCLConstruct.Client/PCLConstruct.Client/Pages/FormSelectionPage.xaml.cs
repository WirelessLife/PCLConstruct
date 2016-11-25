using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLConstruct.Client.Helpers.DTO;
using Newtonsoft.Json;

using Xamarin.Forms;
using PCLConstruct.Client.Views;

namespace PCLConstruct.Client
{
    public partial class FormSelectionPage : ContentPage
    {
        public ObservableCollection<Form> forms;
        public FormSelectionPage(CraftWorker worker)
        {
            InitializeComponent();

            // Set the title
            this.Title = String.Format("{0} {1}'s Forms", worker.FirstName, worker.LastName);

            // Until we have a rest service to hit...
            string jsonStr = "[{\n\t\t\"name\": \"Personnel Action Forms\",\n\t\t\"id\": \"1\",\n\t\t\"description\": \"\",\n\t\t\"sections\": [{\n\t\t\t\"text\": \"Employee Information\",\n\t\t\t\"fields\": [{\n\t\t\t\t\"id\": 1,\n\t\t\t\t\"text\": \"Employee SIN #\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"123123123\",\n\t\t\t\t\"min\": 9,\n\t\t\t\t\"max\": 9,\n\t\t\t\t\"required\": true\n\t\t\t}, {\n\t\t\t\t\"id\": 2,\n\t\t\t\t\"text\": \"Employee #\",\n\t\t\t\t\"type\": \"number\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"26100\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 6,\n\t\t\t\t\"required\": true\n\t\t\t}, {\n\t\t\t\t\"id\": 3,\n\t\t\t\t\"text\": \"First Name\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"John\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 255,\n\t\t\t\t\"required\": true\n\t\t\t}, {\n\t\t\t\t\"id\": 4,\n\t\t\t\t\"text\": \"Middle Initial\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"Q\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 10,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 5,\n\t\t\t\t\"text\": \"Last Name\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"Doe\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 255,\n\t\t\t\t\"required\": true\n\t\t\t}, {\n\t\t\t\t\"id\": 6,\n\t\t\t\t\"text\": \"Maritial Status\",\n\t\t\t\t\"type\": \"radio\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"Common-Law\",\n\t\t\t\t\"options\": [\n\t\t\t\t\t\"Married\",\n\t\t\t\t\t\"Single\",\n\t\t\t\t\t\"Common-Law\"\n\t\t\t\t],\n\t\t\t\t\"required\": true\n\t\t\t}, {\n\t\t\t\t\"id\": 7,\n\t\t\t\t\"text\": \"Date of Birth\",\n\t\t\t\t\"type\": \"date\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"required\": true\n\t\t\t}, {\n\t\t\t\t\"id\": 8,\n\t\t\t\t\"text\": \"Have you previously worked under the Temporary Foreign Worker program with the PCL family of companies?\",\n\t\t\t\t\"type\": \"boolean\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 9,\n\t\t\t\t\"text\": \"The response to the following information request is voluntary. PCL is an equal opportunity employer, and will endeavor to employ as many local and Aboriginal personnel as possible. Please check the response that applies to you\",\n\t\t\t\t\"type\": \"radio\",\n\t\t\t\t\"placeholder\": \"Optional...\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"required\": false,\n\t\t\t\t\"options\": [\n\t\t\t\t\t\"Status Indian/First Nations\",\n\t\t\t\t\t\"Non-Status Indian/First Nations\",\n\t\t\t\t\t\"Metis\",\n\t\t\t\t\t\"Inuit\"\n\t\t\t\t]\n\t\t\t}]\n\t\t}, {\n\t\t\t\"text\": \"Employee Address Information\",\n\t\t\t\"fields\": [{\n\t\t\t\t\"id\": 101,\n\t\t\t\t\"text\": \"Address\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"123 Fake Street\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 100,\n\t\t\t\t\"required\": true\n\t\t\t}, {\n\t\t\t\t\"id\": 102,\n\t\t\t\t\"text\": \"City\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"Edmonton\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 100,\n\t\t\t\t\"required\": true\n\t\t\t}, {\n\t\t\t\t\"id\": 103,\n\t\t\t\t\"text\": \"Province\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"Alberta\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 255,\n\t\t\t\t\"required\": true\n\t\t\t}, {\n\t\t\t\t\"id\": 104,\n\t\t\t\t\"text\": \"Postal Code\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"S4V 0T2\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 6,\n\t\t\t\t\"required\": true\n\t\t\t}, {\n\t\t\t\t\"id\": 105,\n\t\t\t\t\"text\": \"Home Phone #\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"(780) 123-1234\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 20,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 106,\n\t\t\t\t\"text\": \"Cell Phone #\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 20,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 107,\n\t\t\t\t\"text\": \"Mailing Address(if different than residence)\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 100,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 108,\n\t\t\t\t\"text\": \"Mailing City (if different than residence)\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 100,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 109,\n\t\t\t\t\"text\": \"Mailing Province (if different than residence)\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 255,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 110,\n\t\t\t\t\"text\": \"Mailing Postal Code (if different than residence)\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 6,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 111,\n\t\t\t\t\"text\": \"Email Address\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 50,\n\t\t\t\t\"required\": false\n\t\t\t}]\n\t\t}, {\n\t\t\t\"text\": \"Emergency Contact Information\",\n\t\t\t\"fields\": [{\n\t\t\t\t\"id\": 201,\n\t\t\t\t\"text\": \"Name\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 100,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 202,\n\t\t\t\t\"text\": \"Relationship\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 100,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 203,\n\t\t\t\t\"text\": \"Address\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 100,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 204,\n\t\t\t\t\"text\": \"City\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 100,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 205,\n\t\t\t\t\"text\": \"Province\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 255,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 206,\n\t\t\t\t\"text\": \"Postal Code\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 6,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 207,\n\t\t\t\t\"text\": \"Home Phone #\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 20,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 208,\n\t\t\t\t\"text\": \"Work Phone #\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 20,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 209,\n\t\t\t\t\"text\": \"Cell Phone #\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 20,\n\t\t\t\t\"required\": false\n\t\t\t}]\n\t\t}]\n\t},\n\n\t{\n\t\t\"name\": \"Consent for the Collection, Use and Disclosure of Personal Information\",\n\t\t\"id\": \"2\",\n\t\t\"description\": \"\",\n\t\t\"sections\": [{\n\t\t\t\"text\": \"\",\n\t\t\t\"fields\": [{\n\t\t\t\t\"id\": 301,\n\t\t\t\t\"text\": \"Name\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"John Doe\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 255,\n\t\t\t\t\"required\": true\n\t\t\t}, {\n\t\t\t\t\"id\": 302,\n\t\t\t\t\"text\": \"SIN\",\n\t\t\t\t\"type\": \"number\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"123123123\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 9,\n\t\t\t\t\"required\": true\n\t\t\t}, {\n\t\t\t\t\"id\": 303,\n\t\t\t\t\"text\": \"Date of Birth\",\n\t\t\t\t\"type\": \"date\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 10,\n\t\t\t\t\"required\": true\n\t\t\t}]\n\t\t}, {\n\t\t\t\"text\": \"Journeyman/Apprentice Checklist\",\n\t\t\t\"fields\": [{\n\t\t\t\t\"id\": 304,\n\t\t\t\t\"text\": \"Is this person a Journeyman in your province?\",\n\t\t\t\t\"type\": \"boolean\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 305,\n\t\t\t\t\"text\": \"Please confirm Journeyman's Number\",\n\t\t\t\t\"type\": \"number\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 10,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 306,\n\t\t\t\t\"text\": \"Date of Issue\",\n\t\t\t\t\"type\": \"date\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 307,\n\t\t\t\t\"text\": \"Does this person's certificate have a Red Seal?\",\n\t\t\t\t\"type\": \"boolean\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 308,\n\t\t\t\t\"text\": \"Please confirm Red Seal No\",\n\t\t\t\t\"type\": \"number\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"min\": 1,\n\t\t\t\t\"max\": 10,\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 309,\n\t\t\t\t\"text\": \"Date of Issue\",\n\t\t\t\t\"type\": \"date\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 310,\n\t\t\t\t\"text\": \"If no Read Seal, is this person eligible to write the Red Deal exam?\",\n\t\t\t\t\"type\": \"boolean\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 311,\n\t\t\t\t\"text\": \"Is this person a current (active) Apprentice in your province?\",\n\t\t\t\t\"type\": \"boolean\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 312,\n\t\t\t\t\"text\": \"Is this person an Apprentice or Journeyman in more than one trade?\",\n\t\t\t\t\"type\": \"boolean\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 313,\n\t\t\t\t\"text\": \"Other Trades\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 314,\n\t\t\t\t\"text\": \"\",\n\t\t\t\t\"type\": \"text\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"required\": false\n\t\t\t}, {\n\t\t\t\t\"id\": 315,\n\t\t\t\t\"text\": \"Is this Apprentice allowed to use employment hours from Alberta towards his Apprenticeship in the province?\",\n\t\t\t\t\"type\": \"boolean\",\n\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\"value\": \"\",\n\t\t\t\t\"required\": false\n\t\t\t}]\n\t\t}]\n\t},\n\n\t{\n\t\t\"name\": \"Direct Deposit Application / Change Form\",\n\t\t\"id\": \"2\",\n\t\t\"description\": \"\",\n\t\t\"sections\": [{\n\t\t\t\"text\": \"\",\n\t\t\t\"fields\": [{\n\t\t\t\t\t\"id\": 317,\n\t\t\t\t\t\"text\": \"Employee Name\",\n\t\t\t\t\t\"type\": \"text\",\n\t\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\t\"value\": \"John Doe\",\n\t\t\t\t\t\"min\": 1,\n\t\t\t\t\t\"max\": 255,\n\t\t\t\t\t\"required\": true\n\t\t\t\t}, {\n\t\t\t\t\t\"id\": 318,\n\t\t\t\t\t\"text\": \"Project Name\",\n\t\t\t\t\t\"type\": \"text\",\n\t\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\t\"value\": \"Some Project 123\",\n\t\t\t\t\t\"min\": 1,\n\t\t\t\t\t\"max\": 255,\n\t\t\t\t\t\"required\": true\n\t\t\t\t}, {\n\t\t\t\t\t\"id\": 319,\n\t\t\t\t\t\"text\": \"Employee No.\",\n\t\t\t\t\t\"type\": \"number\",\n\t\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\t\"value\": \"26100\",\n\t\t\t\t\t\"min\": 1,\n\t\t\t\t\t\"max\": 6,\n\t\t\t\t\t\"required\": true\n\t\t\t\t}, {\n\t\t\t\t\t\"id\": 320,\n\t\t\t\t\t\"text\": \"Project No.\",\n\t\t\t\t\t\"type\": \"number\",\n\t\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\t\"value\": \"28379234235\",\n\t\t\t\t\t\"min\": 1,\n\t\t\t\t\t\"max\": 20,\n\t\t\t\t\t\"required\": true\n\t\t\t\t}, {\n\t\t\t\t\t\"id\": 321,\n\t\t\t\t\t\"text\": \"Action Type\",\n\t\t\t\t\t\"type\": \"radio\",\n\t\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\t\"value\": \"Setup\",\n\t\t\t\t\t\"required\": true,\n\t\t\t\t\t\"options\": [\n\t\t\t\t\t\t\"Setup\",\n\t\t\t\t\t\t\"Change\",\n\t\t\t\t\t\t\"Reactivate (re-hires only)\"\n\t\t\t\t\t]\n\t\t\t\t}, {\n\t\t\t\t\t\"text\": \"I hearby authorize Intracon Power Inc. to deposit my payroll directly to the account information provided with this form.\",\n\t\t\t\t\t\"type\": \"label\"\n\t\t\t\t}, {\n\t\t\t\t\t\"text\": \"Please review the following information pertaining to Direct Deposit prior to authorization\",\n\t\t\t\t\t\"type\": \"label\"\n\t\t\t\t}, {\n\t\t\t\t\t\"text\": \"   1. Payments are deposited only on designated 'paydays'.\",\n\t\t\t\t\t\"type\": \"label\"\n\t\t\t\t}, {\n\t\t\t\t\t\"id\": 322,\n\t\t\t\t\t\"text\": \"   2. A void personal cheque or bank certification of branch, bank, and account number MUST be provided with this form. Please indicate the type of account by seecting one of the following\",\n\t\t\t\t\t\"type\": \"radio\",\n\t\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\t\"value\": \"Chequing Account\",\n\t\t\t\t\t\"required\": true,\n\t\t\t\t\t\"options\": [\n\t\t\t\t\t\t\"Chequing Account\",\n\t\t\t\t\t\t\"Savings Account\",\n\t\t\t\t\t\t\"Previously set up with PCL Intracon Power. No change.\"\n\t\t\t\t\t]\n\t\t\t\t}, {\n\t\t\t\t\t\"text\": \"   3. Changes to direct deposit information should be submitted 10 days in advance.\",\n\t\t\t\t\t\"type\": \"label\"\n\t\t\t\t},\n\n\t\t\t\t{\n\t\t\t\t\t\"id\": 323,\n\t\t\t\t\t\"text\": \"Bank #\",\n\t\t\t\t\t\"type\": \"number\",\n\t\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\t\"value\": \"32135\",\n\t\t\t\t\t\"min\": 1,\n\t\t\t\t\t\"max\": 20,\n\t\t\t\t\t\"required\": true\n\t\t\t\t}, {\n\t\t\t\t\t\"id\": 323,\n\t\t\t\t\t\"text\": \"Branch #\",\n\t\t\t\t\t\"type\": \"number\",\n\t\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\t\"value\": \"12413123123\",\n\t\t\t\t\t\"min\": 1,\n\t\t\t\t\t\"max\": 20,\n\t\t\t\t\t\"required\": true\n\t\t\t\t},\n\n\t\t\t\t{\n\t\t\t\t\t\"id\": 323,\n\t\t\t\t\t\"text\": \"Account #\",\n\t\t\t\t\t\"type\": \"number\",\n\t\t\t\t\t\"placeholder\": \"\",\n\t\t\t\t\t\"value\": \"1231312314\",\n\t\t\t\t\t\"min\": 1,\n\t\t\t\t\t\"max\": 20,\n\t\t\t\t\t\"required\": true\n\t\t\t\t}\n\n\n\t\t\t]\n\t\t}]\n\t}\n\n]";
            forms = JsonConvert.DeserializeObject<ObservableCollection<Form>>(jsonStr);
            
            lstForms.ItemsSource = this.forms;
            lstForms.BindingContext = this;
            NavigationPage.SetHasBackButton(this, false);

            // Bind item taps to forward to the form rendering page
            lstForms.ItemTapped += (sender, args) => { onFormSelected((Form)args.Item); };

            // Bind the submit button
            btnSubmit.Clicked += async(sender, args) => {
                

                if (AllFormsComplete())
                {
                    string jsonToSave = JsonConvert.SerializeObject(forms);
                    //submit here
                    await DisplayAlert("Submission Complete", "Thank you!  Please return this device to the admin", "Ok (admin only)");
                    //Navigation.PopAsync(true);
                    Backbutton();
                }
                else {
                    DisplayAlert("Forms Incomplete","One or more of your forms are incomplete.","Ok");
                }

            };
            btnExit.Clicked += (sender, args) =>
            {
                Backbutton();
            };
        }


        public async void Backbutton()
        {
            //if save success, jump to the pin auth page.
            await Navigation.PushModalAsync(
              new PinAuthView()
             );
            
        }
        protected override bool OnBackButtonPressed()
        {
            Backbutton();
            return true;
        }

        private bool AllFormsComplete() {
            foreach (Form form in forms)
            {
                if (form.status2 != Controls.FormStatus.Complete)
                {
                    return false;
                }
            }
            return true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            btnSubmit.IsEnabled = AllFormsComplete();
        }

        private async Task onFormSelected(Form tappedForm){
            Form formInList = forms.FirstOrDefault(f => f.Id == tappedForm.Id);
            tappedForm.status2 = Controls.FormStatus.InProgress;
          
            await Navigation.PushAsync(new FormViewer(tappedForm));
        }
    }
}
