
pushd ../src/
docker kill $(docker ps -q)
docker rm $(docker ps -a -q)
docker-compose build
popd