@rem
@rem Copyright (C) 2021 PatrickKR
@rem
@rem Licensed under the Apache License, Version 2.0 (the "License");
@rem you may not use this file except in compliance with the License.
@rem You may obtain a copy of the License at
@rem
@rem     http://www.apache.org/licenses/LICENSE-2.0
@rem
@rem Unless required by applicable law or agreed to in writing, software
@rem distributed under the License is distributed on an "AS IS" BASIS,
@rem WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
@rem See the License for the specific language governing permissions and
@rem limitations under the License.
@rem

dotnet "C:\Program Files\dotnet\sdk\5.0.301\MSBuild.dll" /p:Configuration=Release
mkdir Release
cd ./Release
mkdir SansMod
cp ../SansMod/bin/Release/SansMod.dll ./SansMod/SansMod.dll
cp ../Info.json ./SansMod/Info.json
tar -acf SansMod-Release.zip SansMod
mv SansMod-Release.zip ../
cd ../
rm -rf Release
pause
