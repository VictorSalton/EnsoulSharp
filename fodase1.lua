
print("v3")

wait(5)
local wantedFruits = {
	"Quake Fruit",
	"Buddha Fruit",
	"Portal Fruit",
	"Blizzard Fruit",
	"Gravity Fruit",
	"Dough Fruit",
	"Shadow Fruit",
	"Venom Fruit",
	"Control Fruit",
	"Spirit Fruit",
	"Dragon Fruit",
	"Leopard Fruit"
 }
 
 local Settings = {}
 local HttpService = game:GetService("HttpService")
 local Workspace = game:GetService("Workspace")
 
 local SaveFileName = "bloxfruitsFruits.json"
 
 local function SaveSettings()
  local HttpService = game:GetService("HttpService")
  writefile(SaveFileName, HttpService:JSONEncode(Settings))
 end
 
 local function ReadSetting()
  local s,e = pcall(function()
	  local HttpService = game:GetService("HttpService")
	  return HttpService:JSONDecode(readfile(SaveFileName))
  end)
  if s then return e
  else
	  SaveSettings()
	  return ReadSetting()
  end
 end
 Settings = ReadSetting()
 
 local function HopServer()
  local function Hop()
	  for i=1,200 do
		  local serverlist = game:GetService("ReplicatedStorage").__ServerBrowser:InvokeServer(i)
		  for k,v in pairs(serverlist) do
			  if k~=game.JobId and v.Count < 11 then
				  if not Settings[k] or tick() - Settings[k].Time > 60*60  then
					   Settings[k] = {
						   Time = tick()
					   }
					   SaveSettings()
					  game:GetService("ReplicatedStorage").__ServerBrowser:InvokeServer("teleport",k)
					  return true
				  elseif tick() - Settings[k].Time > 60*120 then
					  Settings[k] = nil
				  end
			  end
		  end
	  end
	  return false
  end
  if not getgenv().Loaded then
	  local function child(childinstance)
		  if childinstance.Name == "ErrorPrompt" then
			  if childinstance.Visible then
				  if childinstance.TitleFrame.ErrorTitle.Text == "Teleport Failed" then
					  HopServer()
				  end
			  end
			  childinstance:GetPropertyChangedSignal("Visible"):Connect(function()
				  if childinstance.Visible then
					  if childinstance.TitleFrame.ErrorTitle.Text == "Teleport Failed" then
						  HopServer()
					  end
				  end
			  end)
		  end
	  end
	  for k,v in pairs(game.CoreGui.RobloxPromptGui.promptOverlay:GetChildren()) do
		  child(v)
	  end
	  game.CoreGui.RobloxPromptGui.promptOverlay.ChildAdded:Connect(child)
	  getgenv().Loaded = true
  end
  while not Hop() do wait() end
  SaveSettings()
 end
 
 repeat
	task.wait()
 until game:IsLoaded() and game.Players.LocalPlayer:FindFirstChild("PlayerGui") and game.Players.LocalPlayer:FindFirstChild("PlayerGui"):FindFirstChild("Main")
 --Check if player is loaded and
 print("Main Menu Loaded")
 
 

 wait(5)
 while true do
	local model = game.Workspace:FindFirstChild("Fruit ")
	if not model or not model:IsA("Model") then
	print("Fruit not Found")
	break
	end
	
	local tweenService, tweenInfo = game:GetService("TweenService"), TweenInfo.new(
		(game.Players.LocalPlayer.Character.HumanoidRootPart.Position - model:FindFirstChild("Handle").Position).magnitude / 300,
		Enum.EasingStyle.Linear
	)
	local tween = tweenService:Create(
		game.Players.LocalPlayer.Character.HumanoidRootPart,
		tweenInfo,
		{CFrame = CFrame.new(model:FindFirstChild("Handle").Position)}
	)
	tween:Play()
	tween.Completed:Wait()
	wait(1)
	for _, fruitName in ipairs(wantedFruits) do
		if game.Players.LocalPlayer.Character:FindFirstChild(fruitName) then
				print("Found ".. fruitName)
				local name = tostring(fruitName.Name)
				local split = string.split(name, " ")
				local word = split[1]
				local args = {
						[1] = "StoreFruit",
						[2] = word.. "-" ..word,
						[3] = game:GetService("Players").LocalPlayer.Character:FindFirstChild(name)
				}
 
				game:GetService("ReplicatedStorage").Remotes.CommF_:InvokeServer(unpack(args))
				keypress(8)
	else
		wait(1)
		keypress(8)
		end
	end
 end
 
 wait(5)
 HopServer()
