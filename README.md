# Workout Planner
REST API created using .NET Core framework. It allows you to create your workout routines and assign exercises to it. Exercise itself it's fully editable, so you can change almost everything by yourself. You can assign a name, type of muscle, numbers of sets and reps, additional weight, set rest time and even create personal notes.

## Technologies used
* C#
* .NET Core
* MSSQL Database

## Running on docker
****
**_Make sure you created Dockerfile and docker-compose.yml using example template file with corresponding variables_**

****
```
git clone https://github.com/PiotrBlachnio/Workout-Planner.git
```

```
cd Workout-Planner/
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
cd Workout-Planner/
```

```
dotnet build
```

```
dotnet run
```

## Contributing
1. Fork it (https://github.com/PiotrBlachnio/Workout-Planner/fork)
1. Create your feature branch (git checkout -b feature/fooBar)
1. Commit your changes (git commit -am 'Add some fooBar')
1. Push to the branch (git push origin feature/fooBar)
1. Create a new Pull Request

## Check it by yourself
[API Documentation](http://ec2-3-92-200-108.compute-1.amazonaws.com/swagger/index.html)

[AWS](http://ec2-3-92-200-108.compute-1.amazonaws.com/)