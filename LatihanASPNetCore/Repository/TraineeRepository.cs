using Dapper;
using LatihanASPNetCore.Model;
using LatihanASPNetCore.Model.BodyRequest;
using System.Data;

namespace LatihanASPNetCore.Repository
{
    public class TraineeRepository
    {
        private readonly IDbConnection connection;

        public TraineeRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public List<Trainee> GetTrainees()
        {
            var query = "SELECT * FROM TBTrainee";

            return connection.Query<Trainee>(query).ToList();
        }

        public Trainee GetTraineeById(int? traineeId)
        {
            var query = "SELECT * FROM TBTrainee WHERE TraineeId = @TraineeId";
            var param = new
            {
                TraineeId = traineeId,
            };

            return connection.QuerySingleOrDefault<Trainee>(query, param);
        }

        public Trainee GetTraineeByCode(string? traineeCode)
        {
            var query = "SELECT * FROM TBTrainee WHERE TraineeCode = @TraineeCode";
            var param = new
            {
                TraineeCode = traineeCode,
            };

            return connection.QuerySingleOrDefault<Trainee>(query, param);
        }

        public void PostTrainee(TraineeBodyRequest? trainee)
        {
            var query = @"INSERT INTO TBTrainee (TraineeCode, TraineeName, Religion, CourseName) 
                VALUES (@TraineeCode, @TraineeName, @Religion, @CourseName)";
            var param = new
            {
                TraineeCode = trainee.TraineeCode,
                TraineeName = trainee.TraineeName,
                Religion = trainee.Religion,
                CourseName = trainee.CourseName,
            };

            connection.Execute(query, param);
        }
    }
}
