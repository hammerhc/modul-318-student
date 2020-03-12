namespace SwissTransport
{
    public interface ITransport
    {
        Stations GetStations(string query);
        Stations GetStationsByCoordinates(string xCoord, string yCoord);
        StationBoardRoot GetStationBoard(string station, string id);
        Connections GetConnections(string fromStation, string toStation);
        Connections GetConnectionsByTime(string fromStation, string toStation, string date, string time, bool timeType);
    }
}