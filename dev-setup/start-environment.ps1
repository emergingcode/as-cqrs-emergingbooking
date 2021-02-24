param(
  [int]$WaitTimeForContainersUp = 10,
  [String[]] $TopicNames,
  [switch]$DebugMode = $False
)

$DebugModeCommand = "-d";

if ($DebugMode) {
  Write-Host "Activating debug mode"

  $DebugModeCommand = ""
}

docker-compose -f docker-compose.yaml up $DebugModeCommand;

Write-Host "Waiting $WaitTimeForContainersUp before starting to create topics"

Start-Sleep -s $WaitTimeForContainersUp

Write-Host "Creating Topics"

foreach ($topic in $TopicNames) {
  Write-Host "Creating topic: $topic"
  $CreateTopicCommand = "kafka-topics --create --topic " + $topic + " --partitions 3 --replication-factor 1 --if-not-exists --zookeeper  zookeeper:22181"
  docker exec -it dev-setup_kafka_1 bash -c "$CreateTopicCommand"
  Write-Host "Waiting 3s before creating another topic"
  Start-Sleep -s 3
  #Write-Host $CreateTopicCommand
}

Write-Host "Topics were created"

Write-Host "Removing containers in ""exited"" status"
docker rm $(docker ps -q --filter status=exited)
Write-Host "Containers in ""exited"" status were removed"