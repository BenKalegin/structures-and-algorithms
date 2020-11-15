namespace interview_questions.geeks4geeks.Design.Elevator
{

	interface IPassengerHallBoundary
	{
		void RequestToRide(Direction direction, int numberOfButton);
		bool PendingRequestIndicator();


		int RequestButtonState(int buttonNumber);
		float CurrentFloor(int carNumber);
		Direction CurrentDirection(int carNumber);
	}

	interface IPassengerCarControlPanel
	{
		void Floor(int floor);
		void DoNotCloseDoors();
		void CloseDoors();
		void OperatorAssistance();

	}

	interface IShaftCarBoundary
	{
		// Commands
		void PassingHeight(int heightSensorNumber);
	}

	interface ICarEngine
	{
		void Rotate(Direction direction, float startRpm, float endRpm, float accelerationTime);

		// query
		float VerticalPosition();
	}

	interface ICar
	{
		
	}


	internal enum Direction
	{
		Up,
		Down
	}
}
