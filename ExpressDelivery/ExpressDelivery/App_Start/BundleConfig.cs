using System.Web;
using System.Web.Optimization;

namespace ExpressDelivery
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/bootstrap-core-css").Include(
                      "~/Content/css/bootstrap*",
                      "~/Content/css/theme*",
                      "~/Content/css/bootstrap-reset*"));
            bundles.Add(new StyleBundle("~/bundles/external-css").Include(
                      "~/Content/assets/font-awesome/css/font-awesome*",
                      "~/Content/css/flexslider*",
                      "~/Content/assets/bxslider/jquery.bxslider*",
                      "~/Content/assets/owlcarousel/owl.carousel*",
                      "~/Content/assets/owlcarousel/owl.theme*",
                      "~/Content/css/superfish*",
                      "~/http://fonts.googleapis.com/css?family=Lato",
                      "~/Content/css/parallax-slider/parallax-slider*",
                      "~/Content/css/animate*"));
            bundles.Add(new StyleBundle("~/bundles/custom-styles*").Include(
                      "~/Content/css/component*",
                      "~/Content/css/style*",
                      "~/Content/css/style-responsive*",
                      "~/Content/css/Site*"));



            bundles.Add(new ScriptBundle("~/bundles/custom-js").Include(
                        "~/Content/js/parallax-slider/modernizr.custom.28468*",
                        "~/Content/js/parallax-slider/modernizr.custom.28468*"));
            bundles.Add(new ScriptBundle("~/bundles/external-js").Include(
                        "~/Content/js/hover-dropdown*",
                        "~/Content/assets/bxslider/jquery.bxslider*",
                        "~/Content/js/jquery.parallax-1.1.3*",
                        "~/Content/js/wow.min*",
                        "~/Content/assets/owlcarousel/owl.carousel*",
                        "~/Content/js/jquery.easing.min*",
                        "~/Content/js/link-hover*",
                        "~/Content/js/superfish*",
                        "~/Content/js/parallax-slider/jquery.cslider*",
                        "~/Content/js/jquery.flexslider*"));
            bundles.Add(new ScriptBundle("~/bundles/common*").Include(
                        "~/Content/js/common-scripts*"));
            bundles.Add(new ScriptBundle("~/bundles/sliding-form").Include(
                  "~/Content/js/sliding.form*"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
