using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Mode;

namespace YF.MWS.Metadata.UI
{
    public class GridColumnProperties : Singleton<GridColumnProperties>
    {
        #region GridLookUpEditColumnProperties

        public List<ColumnProperty> LCorp = new List<ColumnProperty>
         {       
               new  ColumnProperty(){  FieldName="CompanyName", Caption="公司名称",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="Contacter", Caption="联系人",ReadOnly=true},
               new  ColumnProperty(){  FieldName="Tel", Caption = "公司电话",ReadOnly=true}
         };

        public List<ColumnProperty> LCustomer = new List<ColumnProperty>
         {       
               new  ColumnProperty(){  FieldName="CustomerName", Caption="客户名称",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="Contacter", Caption="联系人",ReadOnly=true},
               new  ColumnProperty(){  FieldName="Email", Caption = "客户邮箱",ReadOnly=true},
               new  ColumnProperty(){  FieldName="Tel", Caption = "客户电话",ReadOnly=true}
         };

        public List<ColumnProperty> LTemplate = new List<ColumnProperty>
         {       
               new  ColumnProperty(){  FieldName="TemplateName", Caption="模版名称",ReadOnly=true}
         };

        public List<ColumnProperty> LCostCategory = new List<ColumnProperty>
         {
               new  ColumnProperty(){  FieldName="CategoryName", Caption="目录名称"}
         };
        public List<ColumnProperty> LCostItem = new List<ColumnProperty>
         {
               new  ColumnProperty(){  FieldName="ItemName", Caption="名称",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="Model", Caption="规格",ReadOnly=true},
               new  ColumnProperty(){  FieldName="Uom", Caption="单位",ReadOnly=true},
               new  ColumnProperty(){  FieldName="UnitPrice", Caption="单价",ReadOnly=true},
               new  ColumnProperty(){  FieldName="Brand", Caption="品牌",ReadOnly=true}
         };
        public List<ColumnProperty> LProject = new List<ColumnProperty>
         {
               new  ColumnProperty(){  FieldName="ProNo", Caption="项目编号",ReadOnly=true},
               new  ColumnProperty(){  FieldName="ProName", Caption="项目名称",ReadOnly=true},  
               new  ColumnProperty(){  FieldName="StartDate", Caption = "开始日期",ReadOnly=true},
               new  ColumnProperty(){  FieldName="FinishDate", Caption = "完成日期",ReadOnly=true}
         };
        #endregion

        #region GridControlColumnProperties
        public List<ColumnProperty> GCorp = new List<ColumnProperty>
         {
               new  ColumnProperty(){  FieldName="CompanyId", Visible=false},       
               new  ColumnProperty(){  FieldName="CompanyName", Caption="公司名称",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="Contacter", Caption="联系人",ReadOnly=true},
               new  ColumnProperty(){  FieldName="Tel", Caption = "联系电话",ReadOnly=true},      
               new  ColumnProperty(){  FieldName="CreateDate", Caption = "创建日期",ReadOnly=true} 
         };
        public List<ColumnProperty> GProject = new List<ColumnProperty>
         {
               new  ColumnProperty(){  FieldName="WellId", Visible=false}, 
               new  ColumnProperty(){  FieldName="ProjectStatus", Caption = "状态",ReadOnly=true},
               new  ColumnProperty(){  FieldName="WellNo", Caption="项目编号",ReadOnly=true},
               new  ColumnProperty(){  FieldName="ProName", Caption="项目名称",ReadOnly=true},  
               new  ColumnProperty(){  FieldName="TestDate", Caption = "开始日期",ReadOnly=true}
         };
        public List<ColumnProperty> GCustomer = new List<ColumnProperty>
         {
               new  ColumnProperty(){  FieldName="CustomerId", Visible=false},       
               new  ColumnProperty(){  FieldName="CustomerName", Caption="客户名称",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="Email", Caption = "客户邮箱",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="Tel", Caption = "客户电话",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="Fax", Caption = "客户传真",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="Contacter", Caption="联系人",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="CreateDate", Caption = "创建日期",ReadOnly=true} 
         };
        public List<ColumnProperty> GSupplier = new List<ColumnProperty>
         {
               new  ColumnProperty(){  FieldName="SupplierId", Visible=false},       
               new  ColumnProperty(){  FieldName="CompanyName", Caption="公司名称",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="Contacter", Caption="联系人",ReadOnly=true},
               new  ColumnProperty(){  FieldName="Tel", Caption = "联系电话",ReadOnly=true},      
               new  ColumnProperty(){  FieldName="CreateDate", Caption = "创建日期",ReadOnly=true} 
         };
        public List<ColumnProperty> GTemplate = new List<ColumnProperty>
         {
               new  ColumnProperty(){  FieldName="TemplateId", Visible=false},       
               new  ColumnProperty(){  FieldName="ReportType", Caption="报告类型"}, 
               new  ColumnProperty(){  FieldName="TemplateName", Caption="模板名称"},
               new  ColumnProperty(){  FieldName="CreateDate", Caption = "创建日期",ReadOnly=true} 
         };
        public List<ColumnProperty> GCostCategory = new List<ColumnProperty>
         {
               new  ColumnProperty(){  FieldName="CategoryId", Visible=false},       
               new  ColumnProperty(){  FieldName="CategoryName", Caption="目录名称"}, 
               new  ColumnProperty(){  FieldName="OrderNo", Caption="排序号"},
               new  ColumnProperty(){  FieldName="CreateDate", Caption = "创建日期",ReadOnly=true} 
         };

        public List<ColumnProperty> GCostItem = new List<ColumnProperty>
         {
               new  ColumnProperty(){  FieldName="ItemId", Visible=false},      
               new  ColumnProperty(){  FieldName="CategoryId", ColumnEditName="Category",Caption="分类",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="ItemName", Caption="名称",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="Model", Caption="规格",ReadOnly=true},
               new  ColumnProperty(){  FieldName="Uom", Caption="单位",ReadOnly=true},
               new  ColumnProperty(){  FieldName="UnitPrice", Caption="单价",ReadOnly=true},
               new  ColumnProperty(){  FieldName="Brand", Caption="品牌",ReadOnly=true},
               new  ColumnProperty(){  FieldName="CreateDate", Caption = "创建日期",ReadOnly=true} 
         };
        public List<ColumnProperty> GProCost = new List<ColumnProperty>
         {
               new  ColumnProperty(){  FieldName="ItemId", Visible=false},      
               new  ColumnProperty(){  FieldName="CategoryId", ColumnEditName="Category",Caption="分类",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="CategoryName",Caption="分类",ReadOnly=true,Visible=false}, 
                new  ColumnProperty(){  FieldName="Quantity", Caption="工程量",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="ItemName", Caption="名称",ReadOnly=true}, 
               new  ColumnProperty(){  FieldName="Model", Caption="规格",ReadOnly=true},
               new  ColumnProperty(){  FieldName="Uom", Caption="单位",ReadOnly=true},
               new  ColumnProperty(){  FieldName="UnitPrice", Caption="单价",ReadOnly=true},
               new  ColumnProperty(){  FieldName="Brand", Caption="品牌",ReadOnly=true},
               new  ColumnProperty(){  FieldName="TradeDate", Caption = "登记日期",ReadOnly=true},
               new  ColumnProperty(){  FieldName="CreateDate", Caption = "创建日期",ReadOnly=true} 
         };
        #endregion
        #region TreeListColumnProperties

        public List<ColumnProperty> TCode = new List<ColumnProperty>
         {
               new  ColumnProperty(){  FieldName="ItemCaption", Caption="标题"},       
               new  ColumnProperty(){  FieldName="ItemCode", Caption="编码"},    
               new  ColumnProperty(){  FieldName="OrderNo", Caption="排序号"},
               new  ColumnProperty(){  FieldName ="SystemFlag",Visible=false,ReadOnly=true},             
               new  ColumnProperty(){  FieldName="CreateDate", Caption="创建时间",ReadOnly=true},
               new  ColumnProperty(){  FieldName="EditDate", Caption="修改时间", ReadOnly=true} 
         };
        public List<ColumnProperty> TTempItem = new List<ColumnProperty>
         { 
               new  ColumnProperty(){  FieldName="TemplateId",Visible=false }, 
               new  ColumnProperty(){  FieldName="No", Caption = "序号"},     
               new  ColumnProperty(){  FieldName="ItemName", Caption="名称"}, 
               new  ColumnProperty(){  FieldName="LevelNo", Caption="级别",Visible=false},             
               new  ColumnProperty(){  FieldName="CreateDate", Visible = false, ReadOnly=true} 
         };
        public List<ColumnProperty> TProReport = new List<ColumnProperty>
         { 
               new  ColumnProperty(){  FieldName="RepId",Visible=false }, 
               new  ColumnProperty(){  FieldName="No", Caption = "序号"},     
               new  ColumnProperty(){  FieldName="ItemName", Caption="名称"}, 
               new  ColumnProperty(){  FieldName="LevelNo", Caption="级别",Visible=false},
               new  ColumnProperty(){  FieldName="ProId", Caption="项目编号",Visible=false},
               new  ColumnProperty(){  FieldName="ReportType", Caption="报表类型",Visible=false},             
               new  ColumnProperty(){  FieldName="CreateDate", Visible = false, ReadOnly=true} 
         };
        #endregion
    }
}
