file(GLOB LIB_SRC "**/*.cpp" "*.cpp" "**/*.h" "*.h")

add_definitions(-DCPLUSPLUS)
add_library(EnvironmentTweakerNative SHARED ${LIB_SRC})