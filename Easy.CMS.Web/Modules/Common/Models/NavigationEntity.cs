/* http://www.zkea.net/ Copyright 2016 ZKEASOFT http://www.zkea.net/licenses */
using Easy.MetaData;
using Easy.Models;
using Easy.Web.CMS;

namespace Easy.CMS.Common.Models
{
    [DataConfigure(typeof(NavigationEntityMeta))]
    public class NavigationEntity : EditorEntity
    {
        public string ID { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsMobile { get; set; }
        public string ParentId { get; set; }
        public string Url { get; set; }
        public bool IsCurrent { get; set; }
    }
    class NavigationEntityMeta : DataViewMetaData<NavigationEntity>
    {
        protected override void DataConfigure()
        {
            DataTable("Navigation");
            DataConfig(m => m.ID).AsPrimaryKey();
            DataConfig(m => m.IsCurrent).Ignore();
        }

        protected override void ViewConfigure()
        {
            ViewConfig(m => m.ID).AsHidden();
            ViewConfig(m => m.ParentId).AsHidden();
            ViewConfig(m => m.DisplayOrder).AsHidden();
            ViewConfig(m => m.Title).AsTextBox().Required().Order(1);
            ViewConfig(m => m.Url).AsTextBox().Required().Order(2).AddClass("select").AddProperty("data-url", Urls.SelectPage);
            ViewConfig(m => m.IsMobile).AsCheckBox();
            ViewConfig(m => m.IsCurrent).AsHidden();
        }
    }

}