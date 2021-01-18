# Workout Planner
REST API that allows you to create your workout routines and assign different exercises to them. Exercise is fully editable, so you can adjust it to yourself. You can assign a name, type of muscle, numbers of sets and reps, additional weight, set rest time and even create personal notes.

## Technologies used
* C#
* .NET Core
* MSSQL Database
* Docker

## Running on docker
****
**_Make sure you created Dockerfile and docker-compose.yml using example template file with corresponding variables_**

****
```
git clone https://github.com/PiotrBlachnio/WorkoutAPI.git
```

```
cd WorkoutAPI/
```

```
docker-compose build
```

```
docker-compose up
```
## Running on localhost
****
**_Make sure you added your database connection string in appsettings.json file_**

****

```
git clone https://github.com/PiotrBlachnio/Workout-Planner.git
```

```
cd WorkoutAPI/
```

```
dotnet build
```

```
dotnet run
```

## Contributing
1. Fork it (https://github.com/PiotrBlachnio/WorkoutAPI/fork)
1. Create your feature branch (git checkout -b feature/fooBar)
1. Commit your changes (git commit -am 'Add some fooBar')
1. Push to the branch (git push origin feature/fooBar)
1. Create a new Pull Request
