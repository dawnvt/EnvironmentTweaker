file(GLOB LIB_SRC "**/*.cpp" "*.cpp")

add_definitions(-DCPLUSPLUS)
add_library(EnvironmentTweakerNative SHARED ${LIB_SRC})