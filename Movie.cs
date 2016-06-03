#region license
// Copyright (C) 2016  Terencio Agozzino
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>
#endregion

using System.Runtime.Serialization;

namespace Movies.Models {

    /// <summary>
    /// Represents all of the movie's details.
    /// </summary>
    [DataContract]
    public class Movie {

        [DataMember]
        public string title { get; set; }

        [DataMember]
        public string year { get; set; }

        [DataMember]
        public string genre { get; set; }

        [DataMember]
        public string rating { get; set; }

        [DataMember]
        public string director { get; set; }

        [DataMember]
        public string[] actors { get; set; }

        [DataMember]
        public string description { get; set; }

        /// <summary>
        /// Initializes a new instance of Movie class.
        /// </summary>
        /// <param name="title">Movie's title</param>
        /// <param name="year">Movie's year</param>
        /// <param name="genre">Movie's genre</param>
        /// <param name="rating">Movie's rating</param>
        /// <param name="director">Movie's director</param>
        /// <param name="actors">Movie's actors</param>
        /// <param name="description">Movie's description</param>
        public Movie(string title, string year, string genre, string rating,
            string director, string[] actors, string description) {
            this.title = title;
            this.year = year;
            this.genre = genre;
            this.rating = rating;
            this.director = director;
            this.actors = actors;
            this.description = description;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Movie() { }
    }
}
