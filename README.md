# Requirements:
    - .NET 5.0 installed
    - Docker v19+ installed
    - Node v10 installed

# build
    - frontend build `cd frontend && npm install && npm run build && cd ..`
    - backend build `cd backend && dotnet build && cd ..`
# To run/debug
    - start the sql server docker instance
        `docker-compose up`
    - start front end build/watch
        to develop, run `npm start`
        to run without changing files run `npm run build`
    - start backend .NET services
        to develop, just use f5 debugging (tested with VSCode, im running a mac, so could not verify on windows w/ Visual Studio)
        to run without debugging, run `dotnet ....(insert path)`
