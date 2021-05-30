using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Count = 1;
        }


        public int Id { get; set; }

        public string UserId { get; set; }

        [NotMapped]
        [ForeignKey("UserId")]
        public virtual Areas.Identity.Data.ArtGalleryUser ArtGalleryUser   { get; set; }

        public int ArtworkId { get; set; }

        [NotMapped]
        [ForeignKey("ArtworkId")]
        public virtual Artwork Artwork { get; set; }



        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than or equal to {1}")]
        public int Count { get; set; }
    }
}
