using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Middlewares
{
    public class SecurityHeadersOptions
    {
        private readonly RequestDelegate _next;

        public SecurityHeadersOptions(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //Security Headers kullanarak güvenliği arttırmak:
            //X-Frame-Options: Uygulamamızın bir pencere içerisinde çağırılmasını yönetir.
            //DENY: Uygulamamız her hangi bir frame/iframe içerisinde çağırılamaz.
            //SAMEORIGIN: Kendi domainimizden başka herhangi bir domainin frame/iframe içerisinde çağırmasını engeller.
            //ALLOW-FROM <URL>: Belirlenen adres üzerinden frame/ifareme yapılmasına izin verir. 
            context.Response.Headers.Add("X-Frame-Options", "DENY");

            //X-XSS-Protection: Injection(xss/cross-site-scripting) saldırıları için eklenir. 
            context.Response.Headers.Add("X-Xss-Protection", "1; model=block");

            //X-Content-Type-Options: MIME Type Sniffing kullanarak dosya bitlerini okuyarak tipine karar verir. Uazantısı .png olan fakat tipi text/html olan bir dosya bu mod açık kaldığı zaman upload edilebilir  fakat sniffing nedeniyle html olarak tetiklenebilir, bu olursa içerisinde zararlı bir kod varsa tetiklenir.
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");

            //Content-Security-Policy: js, css, font vb dosyalar için fazladan güvenlik sağlar.
            string policy = "default-src 'self'; " +
            "img-src 'self' <External-Url>; " +
            "font-src 'self'; " +
            "style-src 'self' https://cdn.jsdelivr.net;" +
            "script-src 'self' https://cdnjs.cloudflare.com;";
            context.Response.Headers.Add("Content-Security-Policy", policy);

            //Referrer-Policy: Bulundurduğumuz dış bağlantıya tıklandığı zaman, nereden geldiği bilgisi üzerine eklenir. Bu yapı eklenen bilgiyi yöner.
            context.Response.Headers.Add("Referrer-Policy", "no-referrer");

            //Feature-Policy: Client side olarak kullanılabilen özelliklerin (görüntü, ses, konum vb) yönetilmesini sağlar.
            context.Response.Headers.Add("Feature-Policy", "camera 'none'; geolocation: 'none'; microphone: 'none'");

            await _next.Invoke(context);
        }
    }
}
