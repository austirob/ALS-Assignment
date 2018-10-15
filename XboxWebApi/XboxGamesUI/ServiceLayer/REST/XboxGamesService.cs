
using System.Collections.Generic;
using RestSharp;
using RestSharp.Serializers;
using XboxGamesUI.Helpers;
using XboxGamesUI.ServiceLayer.Dtos;

namespace XboxGamesUI.ServiceLayer.REST
{
    
    public class XboxGamesService : IXboxGamesService
    {             

        private readonly RestCore _restCore;
        
        public XboxGamesService()
        {  
            _restCore = new RestCore();
        }
       
        public List<GameDto> GetGames()
        {
            var result = _restCore.ExecuteRequest<List<GameDto>>(DisplayStrings.GamesUrl);
            return result;
        }


        public RatingDto SubmitRating(RatingDto RatingDto)
        {

            var response = _restCore.SendJsonWithBody<RatingDto, RatingDto>(RatingDto, Method.POST, DisplayStrings.RatingUrl);
            return response;
        }


        public GameDto CreateGame(GameDto GameDto)
        {

            var response = _restCore.SendJsonWithBody<GameDto, GameDto>(GameDto, Method.POST, DisplayStrings.GamesUrl);
            return response;
        }

        public void UpdateGame(GameDto GameDto)
        {
            _restCore.SendJsonWithBody<GameDto, int>(GameDto, Method.PUT, DisplayStrings.GamesUrl);
        }

        public void DeleteGame(int id)
        {
           
            var request = new RestRequest(DisplayStrings.GamesUrl, Method.DELETE).AddUrlSegment("id", id);
            _restCore.ExecuteRequest(request);
        }

       }
}
