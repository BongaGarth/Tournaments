using System.Web.Optimization;

namespace Template.MVC5
{
    public class BootstrapBundleConfig
    {
        public static void RegisterBundles()
        {
            // Add @Styles.Render("~/Content/bootstrap") in the <head/> of your _Layout.cshtml view
            // For Bootstrap theme add @Styles.Render("~/Content/bootstrap-theme") in the <head/> of your _Layout.cshtml view
            // Add @Scripts.Render("~/bundles/bootstrap") after jQuery in your _Layout.cshtml view
            // When <compilation debug="true" />, MVC4 will render the full readable version. When set to <compilation debug="false" />, the minified version will be rendered automatically
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            BundleTable.Bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css"));
            BundleTable.Bundles.Add(new StyleBundle("~/Content/bootstrap-theme").Include("~/Content/bootstrap-theme.css"));


            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/bootstrap-datepicker.js",
                "~/Scripts/clockpicker.js",
                "~/Scripts/custom.js",
                 "~/Scripts/main.js",
                "~/Scripts/DataTables/jquery.datatables.js",
                "~/Scripts/DataTables/datatables.bootstrap.js",
                "~/Scripts/DataTables/dataTables.buttons.js",
                  "~/Scripts/DataTables/jszip.js",
                "~/Scripts/DataTables/buttons.html5.js",
                  "~/Scripts/DataTables/buttons.print.js",
                "~/Scripts/DataTables/pdfmake.js",
                "~/Scripts/DataTables/vfs_fonts.js",
              "~/Scripts/raphael.min.js",
              "~/Scripts/jquery-ui-1.12.1.min.js",
                "~/Scripts/bootbox.min.js",
                "~/Scripts/venders/iCheck/icheck.min.js",
                "~/Scripts/vendors/autosize",
                "~/Scripts/vendors/select2.full.min.js",
                "~/Scripts/typeahead.bundle.js",
                "~/Scripts/toastr.js",
                "~/Scripts/respond.js"));


            BundleTable.Bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/clockpicker.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/DataTables/css/buttons.dataTables.css",
                      "~/Content/css/custom.css",
                      "~/Content/css/morris.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css",
                      "~/Content/themes/base/jquery-ui.min.css",
                      "~/Content/css/nprogress.css",
                      //"~/Content/fullcalendar.print.css",
                      "~/Content/css/animate.css",
                      "~/Content/iCheck/flat/green.css",
                      "~/Content/css/select2.min.css",
                      //"~/Content/fonts/fontawesome-all.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/themes/base/core.css",
                      "~/Content/themes/base/resizable.css",
                      "~/Content/themes/base/selectable.css",
                      "~/Content/themes/base/accordion.css",
                      "~/Content/themes/base/autocomplete.css",
                      "~/Content/themes/base/button.css",
                      "~/Content/themes/base/dialog.css",
                      "~/Content/themes/base/slider.css",
                      "~/Content/themes/base/tabs.css",
                      "~/Content/themes/base/datepicker.css",
                      "~/Content/themes/base/progressbar.css",
                      "~/Content/themes/base/theme.css"
                ));
        }
    }
}

