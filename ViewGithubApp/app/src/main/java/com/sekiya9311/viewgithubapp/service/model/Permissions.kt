package com.sekiya9311.viewgithubapp.service.model

data class Permissions(
    val admin: Boolean,
    val push: Boolean,
    val pull: Boolean
)
