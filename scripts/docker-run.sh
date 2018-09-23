
pushd ../src/
docker kill $(docker ps -q)
docker-compose up
popd