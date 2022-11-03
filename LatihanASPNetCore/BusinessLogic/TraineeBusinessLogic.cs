using LatihanASPNetCore.Core;
using LatihanASPNetCore.Model;
using LatihanASPNetCore.Model.BodyRequest;
using LatihanASPNetCore.Repository;
using System.Transactions;

namespace LatihanASPNetCore.BusinessLogic
{
    public class TraineeBusinessLogic
    {
        private readonly DBHelper dbHelper;

        public TraineeBusinessLogic(IConfiguration configuration)
        {
            dbHelper = new DBHelper(configuration);
        }

        public List<Trainee> GetTrainees()
        {
            using (var connection = dbHelper.CreateConnection())
            {
                TraineeRepository traineeRepository = new TraineeRepository(connection);

                List<Trainee> trainees = traineeRepository.GetTrainees();

                return trainees;
            }
        }

        public Trainee GetTraineeById(int traineeId)
        {
            using (var connection = dbHelper.CreateConnection())
            {
                TraineeRepository traineeRepository = new TraineeRepository(connection);

                Trainee trainee = traineeRepository.GetTraineeById(traineeId);
                if (trainee == null)
                {
                    throw new NotFoundException($"Data trainee dengan id = {traineeId} tidak ditemukan");
                }

                return trainee;
            }
        }

        public void PostTrainee(TraineeBodyRequest bodyRequest)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = dbHelper.CreateConnection())
                {
                    TraineeRepository traineeRepository = new TraineeRepository(connection);

                    Trainee trainee = traineeRepository.GetTraineeByCode(bodyRequest.TraineeCode);
                    if (trainee != null)
                    {
                        throw new InternalServerErrorException($"Data trainee dengan kode = {bodyRequest.TraineeCode} sudah ada, tidak bisa menambah");
                    }

                    traineeRepository.PostTrainee(bodyRequest);

                    transaction.Complete();
                }
            }
        }
    }
}
