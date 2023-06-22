local HttpService = game:GetService("HttpService")
print("v3")
function HopServer()
  print("HOPSERVER CHAMADO")
  local function Hop()
      print("HOP CHAMADO")
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

local goodFruit = false


spawn(function()
	while wait(5) and goodFruit == false do

        for i,v in pairs(game:GetService("Players").LocalPlayer.Backpack:GetChildren()) do
            if string.find(v.Name, "Fruit") then
                if string.find(v.Name, "Dough") then
                    goodFruit = true;
                end

                if string.find(v.Name, "Dragon") then
                    goodFruit = true;
                end

                if string.find(v.Name, "Leopard") then
                    goodFruit = true;
                end

                if string.find(v.Name, "Shadow") then
                    goodFruit = true;
                end

                if string.find(v.Name, "Control") then
                    goodFruit = true;
                end

                if string.find(v.Name, "Venom") or string.find(v.Name, "Buddha") or string.find(v.Name, "Spirit") then
                    goodFruit = true;
                end
            end
        end

        for i,v in pairs(game:GetService("Players").LocalPlayer.Character:GetChildren()) do
            if string.find(v.Name, "Fruit") then
                if string.find(v.Name, "Dough") then
                    goodFruit = true;
                end

                if string.find(v.Name, "Dragon") then
                    goodFruit = true;
                end

                if string.find(v.Name, "Leopard") then
                    goodFruit = true;
                end

                if string.find(v.Name, "Shadow") then
                    goodFruit = true;
                end

                if string.find(v.Name, "Control") then
                    goodFruit = true;
                end

                if string.find(v.Name, "Venom") or string.find(v.Name, "Buddha") or string.find(v.Name, "Spirit") then
                    goodFruit = true;
                end
            end
        end



		for i,v in pairs(game.Workspace:GetChildren()) do
			if string.find(v.Name, "Fruit") then
				hasFruit = true
				print(v.Name)
				game.Players.LocalPlayer.Character.HumanoidRootPart.CFrame = v.Handle.CFrame
			end
		end

		if(not hasFruit and not goodFruit) then
			print("Not Fruit HOP")
			HopServer()
		else 
			for i,v in pairs(game:GetService("Players").LocalPlayer.Backpack:GetChildren()) do
				if string.find(v.Name, "Fruit") then
					if string.find(v.Name, "Dough") then
						goodFruit = true;
					end

					if string.find(v.Name, "Dragon") then
						goodFruit = true;
					end

					if string.find(v.Name, "Leopard") then
						goodFruit = true;
					end

					if string.find(v.Name, "Shadow") then
						goodFruit = true;
					end

					if string.find(v.Name, "Control") then
						goodFruit = true;
					end

					if string.find(v.Name, "Venom") or string.find(v.Name, "Buddha") or string.find(v.Name, "Spirit") then
						goodFruit = true;
					end
				end
			end

			for i,v in pairs(game:GetService("Players").LocalPlayer.Character:GetChildren()) do
				if string.find(v.Name, "Fruit") then
					if string.find(v.Name, "Dough") then
						goodFruit = true;
					end

					if string.find(v.Name, "Dragon") then
						goodFruit = true;
					end

					if string.find(v.Name, "Leopard") then
						goodFruit = true;
					end

					if string.find(v.Name, "Shadow") then
						goodFruit = true;
					end

					if string.find(v.Name, "Control") then
						goodFruit = true;
					end

					if string.find(v.Name, "Venom") or string.find(v.Name, "Buddha") or string.find(v.Name, "Spirit") then
						goodFruit = true;
					end
				end
			end
			
			if(goodFruit == false) then
				print("SO LIXO HOP")
				HopServer()
			else
				print("FRUTA BOAAAA")
			end
		end
	end
end)
