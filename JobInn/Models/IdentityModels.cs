using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JobInn.Areas.Admin.Models;
using System.Collections.Generic;
using JobInn.Models.TablePage.Employers;
using JobInn.Models.TablePage.Jobseekers;
using JobInn.Models.TablePage.Blogs;
using JobInn.Models.TablePage;

namespace JobInn.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar")]
        [StringLength(20)]
        [Display(Name = "Adınız")]
        public string first_name { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(20)]
        [Display(Name = "Soyadınız")]
        public string last_name { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Profil şəkli")]
        public string profil_img { get; set; }


        public virtual ICollection<Job> job { get; set; }
        public virtual ICollection<Jobseeker> jobseeker { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name =DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        //go areas userpage
        //folder blogs
        public DbSet<Blog> blog { get; set; }
        public DbSet<BlogComment> blogcomment { get; set; }
        public DbSet<CommentReply> commentreply { get; set; }
        //folder employers
        public DbSet<City> city { get; set; }
        public DbSet<Job> job { get; set; }
        public DbSet<JobCategory> jobcategory { get; set; }
        public DbSet<JobType> jobtype { get; set; }
        public DbSet<JobTypeColor> jobtypecolor { get; set; }
        //folder jobseekers
        public DbSet<Education> education { get; set; }
        public DbSet<Experince> experince { get; set; }
        public DbSet<Jobseeker> jobseeker { get; set; }
        public DbSet<Skill> skill { get; set; }
        public DbSet<Url> url { get; set; }
        //folder model
        public DbSet<Company> company { get; set; }
        public DbSet<Contact> contact { get; set; }

        //go areas admin
        public DbSet<PrivacyPolicy> privacypolicy { get; set; }

    }
}