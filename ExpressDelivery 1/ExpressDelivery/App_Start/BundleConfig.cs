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

            bundles.Add(new StyleBundle("~/Content/bootstrap-core-css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/theme.css",
                      "~/Content/css/bootstrap-reset.css"));
            bundles.Add(new StyleBundle("~/Content/external-css").Include(
                      "~/Content/assets/font-awesome/css/font-awesome.css",
                      "~/Content/css/flexslider.css",
                      "~/Content/assets/bxslider/jquery.bxslider.css",
                      "~/Content/assets/owlcarousel/owl.carousel.css",
                      "~/Content/assets/owlcarousel/owl.theme.css",
                      "~/Content/css/superfish.css",
                      "~/http://fonts.googleapis.com/css?family=Lato",
                      "~/Content/css/parallax-slider/parallax-slider.css",
                      "~/Content/css/animate.css"));
            bundles.Add(new StyleBundle("~/Content/custom-styles-css").Include(
                      "~/Content/css/component.css",
                      "~/Content/css/style.css",
                      "~/Content/css/style-responsive.css",
                      "~/Content/css/Site.css"));



            bundles.Add(new ScriptBundle("~/bundles/custom-js").Include(
                        "~/Content/js/parallax-slider/modernizr.custom.28468.js",
                        "~/Content/js/parallax-slider/modernizr.custom.28468.js"));
            bundles.Add(new ScriptBundle("~/bundles/external-js").Include(
                        "~/Content/js/hover-dropdown.js",
                        "~/Content/assets/bxslider/jquery.bxslider.js",
                        "~/Content/js/jquery.parallax-1.1.3.js",
                        "~/Content/js/wow.min.js",
                        "~/Content/assets/owlcarousel/owl.carousel.js",
                        "~/Content/js/jquery.easing.min.js",
                        "~/Content/js/link-hover.js",
                        "~/Content/js/superfish.js",
                        "~/Content/js/parallax-slider/jquery.cslider.js",
                        "~/Content/js/jquery.flexslider.js"));
            bundles.Add(new ScriptBundle("~/bundles/common-js").Include(
                        "~/Content/js/common-scripts.js"));
            bundles.Add(new ScriptBundle("~/bundles/sliding-form").Include(
                  "~/Content/js/sliding.form.js"));
        }
    }
}
