local HttpService = game:GetService("HttpService")

function HopServer()
  local function Hop()
      for i=1,100 do
          local huhu = game:GetService("ReplicatedStorage").__ServerBrowser:InvokeServer(i)
          for k,v in pairs(huhu) do
              if k~=game.JobId and v.Count < 10 then
                game:GetService("ReplicatedStorage").__ServerBrowser:InvokeServer("teleport",k)
                return true
              end
          end
      end
      return false
  end
  if not getgenv().Loaded then
      local function child(v)
          if v.Name == "ErrorPrompt" then
              if v.Visible then
                  if v.TitleFrame.ErrorTitle.Text == "Teleport Failed" then
                      HopServer()
                  end
              end
              v:GetPropertyChangedSignal("Visible"):Connect(function()
                  if v.Visible then
                      if v.TitleFrame.ErrorTitle.Text == "Teleport Failed" then
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
end
HopServer()
