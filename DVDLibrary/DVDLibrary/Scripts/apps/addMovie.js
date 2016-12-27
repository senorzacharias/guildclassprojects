

       $(function() {

           $('#btnSsaveMovie')
               .click(function (evt) {
                   evt.preventDefault();
                   var movie = {};

                   movie.Title = $('#title').val();
                   movie.Id = $('#id').val();
                   movie.Genre = $('#genre').val();
                   movie.UserRating = $('#userRating').val();
                   movie.Director = $('#director').val();
                   movie.MPAARating = $('#mpaaRating').val();
                   movie.Actors = $('#actors').val();
                   movie.ReleaseDate = $('#releaseDate').val();
                   movie.Studio = $('#studio').val();
                   movie.BorrwerId = $('#borrowerId').val();
                   movie.DateBorrowed = $('#dateBorrowed').val();
                   movie.DateReturned = $('#dateReturned').val();
                   movie.UserNotes = $('#userNotes').val();

                  

                   $.post('/api/Home/', movie)
                       .done(function() {
                           loadMovies();
                           $('#addMovieModal').modal('hide');
                           console.log("saved!");   
                       })
                       .fail(function(jqXhr, status, err) {
                           alert(status + '-' + err);
                           console.log("failed!");
                       });
                   return false;
               });
           loadMovies();
       });


